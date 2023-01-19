using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Marten.Exceptions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.Time;
using MyCompany.Crm.TechnicalStuff.Persistence;
using MyCompany.Crm.TechnicalStuff.Postgres;
using Xunit;

namespace MyCompany.Crm.Sales.Orders
{
    public class OrderSqlRepositoryTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly PriceChangesPolicy _priceChangesPolicies = new FakePriceChangesPolicy();
        private readonly SystemClock _clock = new();
        private readonly IServiceProvider _serviceProvider;

        private string _repositoryImplementation;
        
        public OrderSqlRepositoryTests(WebApplicationFactory<Program> appFactory) => 
            _serviceProvider = appFactory.Services;
        
        [Theory]
        [InlineData(nameof(OrderSqlRepository.Raw))]
        [InlineData(nameof(OrderSqlRepository.EF))]
        [InlineData(nameof(OrderSqlRepository.Document))]
        [InlineData(nameof(OrderSqlRepository.EventsSourcing))]
        public async Task RestoredOrderIsEqualToOriginal(string repositoryImplementation)
        {
            _repositoryImplementation = repositoryImplementation;
            var (productAmount1, productAmount2, productAmount3) = CreateProductAmounts();
            var offer1 = CreateOfferFor(productAmount1, productAmount2);
            var offer2 = CreateOfferFor(productAmount1, productAmount2, productAmount3);
            var now = _clock.Now;

            var orderId = await TestRestoreForNewOrder();
            await TestRestoreAfter(orderId, order => order.Add(productAmount1));
            await TestRestoreAfter(orderId, order => order.Add(productAmount2));
            await TestRestoreAfter(orderId, order => order.ConfirmPrices(offer1, _priceChangesPolicies, now.AddDays(2)));
            await TestRestoreAfter(orderId, order => order.Add(productAmount3));
            await TestRestoreAfter(orderId, order => order.ConfirmPrices(offer2, _priceChangesPolicies, now.AddDays(3)));
            await TestRestoreAfter(orderId, order => order.Place(now.AddDays(2)));
            await TestRestoreForOrderFromOffer(offer2);
        }

        [Theory]
        [InlineData(nameof(OrderSqlRepository.Raw))]
        [InlineData(nameof(OrderSqlRepository.EF))]
        [InlineData(nameof(OrderSqlRepository.Document))]
        [InlineData(nameof(OrderSqlRepository.EventsSourcing))]
        public async Task CanNotSaveOrderIfVersionHasChangedInDb(string repositoryImplementation)
        {
            _repositoryImplementation = repositoryImplementation;
            using var scope0 = CreateScope();
            var order = scope0.OrderFactory.NewWith(Money.Of(decimal.MaxValue, Currency.PLN));
            await scope0.OrderRepository.Save(order);
            await scope0.TransactionProvider.CommitCurrentTransaction();
            
            using var scope1 = CreateScope();
            using var scope2 = CreateScope();
            var order1 = await scope1.OrderRepository.GetBy(order.Id);
            var order2 = await scope2.OrderRepository.GetBy(order.Id);
            order1.Add(ProductAmount.Of(ProductId.New(), Amount.Of(3, AmountUnit.Box)));
            order2.Add(ProductAmount.Of(ProductId.New(), Amount.Of(7, AmountUnit.Unit)));
            var action1 = async () =>
            {
                await scope1.OrderRepository.Save(order1);
                await scope1.TransactionProvider.CommitCurrentTransaction();
            };
            var action2 = async () =>
            {
                await scope2.OrderRepository.Save(order2);
                await scope2.TransactionProvider.CommitCurrentTransaction();
            };
            await action1.Should().NotThrowAsync();
            switch (repositoryImplementation)
            {
                case nameof(OrderSqlRepository.Raw):
                    await action2.Should().ThrowExactlyAsync<OptimisticLockException>();
                    break;
                case nameof(OrderSqlRepository.EF):
                    await action2.Should().ThrowExactlyAsync<DbUpdateConcurrencyException>();
                    break;
                case nameof(OrderSqlRepository.Document):
                    await action2.Should().ThrowExactlyAsync<ConcurrencyException>();
                    break;
                case nameof(OrderSqlRepository.EventsSourcing):
                    await action2.Should().ThrowExactlyAsync<EventStreamUnexpectedMaxEventIdException>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_repositoryImplementation),
                        repositoryImplementation,
                        null);
            }
        }

        private static (ProductAmount, ProductAmount, ProductAmount) CreateProductAmounts()
        {
            var product1 = ProductId.New();
            var product2 = ProductId.New();
            var productAmount1 = ProductAmount.Of(
                product1,
                Amount.Of(3, AmountUnit.Palette));
            var productAmount2 = ProductAmount.Of(
                product2,
                Amount.Of(5, AmountUnit.Box));
            var productAmount3 = ProductAmount.Of(
                product2,
                Amount.Of(7, AmountUnit.Unit));
            return (productAmount1, productAmount2, productAmount3);
        }

        private static Offer CreateOfferFor(params ProductAmount[] productAmounts) => Offer.FromQuotes(
            Currency.PLN,
            productAmounts.Select((productAmount, index) => Quote.For(
                productAmount,
                Money.Of((index + 1) * 1.23m, Currency.PLN))));

        private async Task<OrderId> TestRestoreForNewOrder()
        {
            using var scope = CreateScope();
            var order = scope.OrderFactory.NewWith(Money.Of(decimal.MaxValue, Currency.PLN));
            await scope.OrderRepository.Save(order);
            await scope.TransactionProvider.CommitCurrentTransaction();
            await TestRestore(order);
            return order.Id;
        }

        private async Task TestRestoreForOrderFromOffer(Offer offer)
        {
            using var scope = CreateScope();
            var order = scope.OrderFactory.ImmediatelyPlacedBasedOn(offer);
            await scope.OrderRepository.Save(order);
            await scope.TransactionProvider.CommitCurrentTransaction();
            await TestRestore(order);
        }

        private async Task TestRestoreAfter(OrderId orderId, Action<Order> action)
        {
            using var scope = CreateScope();
            var order = await scope.OrderRepository.GetBy(orderId);
            action(order);
            await scope.OrderRepository.Save(order);
            await scope.TransactionProvider.CommitCurrentTransaction();
            await TestRestore(order);
        }

        private async Task TestRestore(Order savedOrder)
        {
            using var scope = CreateScope();
            var restoredOrder = await scope.OrderRepository.GetBy(savedOrder.Id);
            restoredOrder.Should().BeEquivalentTo(savedOrder);
        }

        private Scope CreateScope() => new(_serviceProvider, _repositoryImplementation);

        private class Scope : IDisposable
        {
            private readonly IServiceScope _scope;
            public PostgresTransactionProvider TransactionProvider { get; }
            public Order.Repository OrderRepository { get; }
            public Order.Factory OrderFactory { get; }
            
            public Scope(IServiceProvider serviceProvider, string repositoryImplementation)
            {
                _scope = serviceProvider.CreateScope();
                TransactionProvider = _scope.ServiceProvider.GetRequiredService<PostgresTransactionProvider>();
                OrderRepository = CreateRepository(_scope, repositoryImplementation);
                OrderFactory = CreateFactory(_scope, repositoryImplementation);
            }
            
            public void Dispose()
            {
                TransactionProvider.Dispose();
                _scope.Dispose();
            }

            private static Order.Repository CreateRepository(IServiceScope scope, string repositoryImplementation) =>
                repositoryImplementation switch
                {
                    nameof(OrderSqlRepository.Raw) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.Raw>(),
                    nameof(OrderSqlRepository.EF) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.EF>(),
                    nameof(OrderSqlRepository.Document) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.Document>(),
                    nameof(OrderSqlRepository.EventsSourcing) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.EventsSourcing>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(_repositoryImplementation),
                        repositoryImplementation,
                        null)
                };
            
            private static Order.Factory CreateFactory(IServiceScope scope, string repositoryImplementation) =>
                repositoryImplementation switch
                {
                    nameof(OrderSqlRepository.Raw) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.Raw>(),
                    nameof(OrderSqlRepository.EF) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.EF>(),
                    nameof(OrderSqlRepository.Document) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.Document>(),
                    nameof(OrderSqlRepository.EventsSourcing) => scope.ServiceProvider
                        .GetRequiredService<OrderSqlRepository.EventsSourcing>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(_repositoryImplementation),
                        repositoryImplementation,
                        null)
                };
        }
    }
}