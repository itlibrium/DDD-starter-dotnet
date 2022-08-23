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
using Xunit;

namespace MyCompany.Crm.Sales.Orders
{
    public class OrderSqlRepositoryTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly PriceChangesPolicy _priceChangesPolicies = new FakePriceChangesPolicy();
        private readonly SystemClock _clock = new();
        private readonly IServiceProvider _serviceProvider;

        private string _repositoryImplementation;
        private Scope _scope;

        public OrderSqlRepositoryTests(WebApplicationFactory<Program> appFactory) => _serviceProvider = appFactory
            .WithWebHostBuilder(builder => builder
                .ConfigureServices(services => services
                    .AddScoped<OrderSqlRepository.EF>()
                    .AddScoped<OrderSqlRepository.Document>()
                    .AddScoped<OrderSqlRepository.EventsSourcing>()))
            .Services;

        [Theory]
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

            await TestRestoreForNewOrder();
            await TestRestoreAfter(order => order.Add(productAmount1));
            await TestRestoreAfter(order => order.Add(productAmount2));
            await TestRestoreAfter(order => order.ConfirmPrices(offer1, _priceChangesPolicies, now.AddDays(2)));
            await TestRestoreAfter(order => order.Add(productAmount3));
            await TestRestoreAfter(order => order.ConfirmPrices(offer2, _priceChangesPolicies, now.AddDays(3)));
            await TestRestoreAfter(order => order.Place(now.AddDays(2)));
            await TestRestoreForOrderFromOffer(offer2);
        }

        [Theory]
        [InlineData(nameof(OrderSqlRepository.EF))]
        [InlineData(nameof(OrderSqlRepository.Document))]
        [InlineData(nameof(OrderSqlRepository.EventsSourcing))]
        public async Task CanNotSaveOrderIfVersionHasChangedInDb(string repositoryImplementation)
        {
            _repositoryImplementation = repositoryImplementation;
            using var scope0 = CreateScope();
            scope0.CreateOrder();
            await scope0.SaveOrder();
            var id = scope0.Order.Id;

            var productAmount = ProductAmount.Of(ProductId.New(), Amount.Of(3, AmountUnit.Box));
            using var scope1 = CreateScope();
            using var scope2 = CreateScope();
            await scope1.LoadOrder(id);
            await scope2.LoadOrder(id);
            scope1.Execute(order => order.Add(productAmount));
            scope2.Execute(order => order.Add(productAmount));
            Func<Task> action1 = () => scope1.SaveOrder();
            Func<Task> action2 = () => scope2.SaveOrder();
            await action1.Should().NotThrowAsync();
            switch (repositoryImplementation)
            {
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

        private async Task TestRestoreForNewOrder()
        {
            SetNewScope();
            _scope.CreateOrder();
            await TestRestore();
        }

        private async Task TestRestoreForOrderFromOffer(Offer offer)
        {
            SetNewScope();
            _scope.CreateOrder();
            _scope.Order.ApplyOffer(offer);
            await TestRestore();
        }

        private async Task TestRestoreAfter(Action<Order> action)
        {
            _scope.Execute(action);
            await TestRestore();
        }

        private async Task TestRestore()
        {
            await _scope.SaveOrder();
            var savedOrder = _scope.Order;
            SetNewScope();
            await _scope.LoadOrder(savedOrder.Id);
            var restoredOrder = _scope.Order;
            restoredOrder.Should().Be(savedOrder);
        }

        private void SetNewScope()
        {
            _scope?.Dispose();
            _scope = CreateScope();
        }

        private Scope CreateScope() => new(_serviceProvider, _repositoryImplementation);

        public void Dispose() => _scope?.Dispose();

        private class Scope : IDisposable
        {
            private readonly IServiceScope _scope;
            private readonly OrderRepository _repository;
            public Order Order { get; private set; }

            public Scope(IServiceProvider serviceProvider, string repositoryImplementation)
            {
                _scope = serviceProvider.CreateScope();
                _repository = CreateRepository(_scope, repositoryImplementation);
            }

            public void CreateOrder() => Order = _repository.New();

            public async Task LoadOrder(OrderId id)
            {
                if (Order != null)
                    throw new InvalidOperationException("Order is already set");
                Order = await _repository.GetBy(id);
            }

            public void Execute(Action<Order> action) => action(Order);

            public Task SaveOrder() => _repository.Save(Order);

            public void Dispose() => _scope?.Dispose();

            private static OrderRepository CreateRepository(IServiceScope scope, string repositoryImplementation) =>
                repositoryImplementation switch
                {
                    nameof(OrderSqlRepository.EF) => scope.ServiceProvider
                        .GetService<OrderSqlRepository.EF>(),
                    nameof(OrderSqlRepository.Document) => scope.ServiceProvider
                        .GetService<OrderSqlRepository.Document>(),
                    nameof(OrderSqlRepository.EventsSourcing) => scope.ServiceProvider
                        .GetService<OrderSqlRepository.EventsSourcing>(),
                    _ => throw new ArgumentOutOfRangeException(nameof(_repositoryImplementation),
                        repositoryImplementation,
                        null)
                };
        }
    }
}