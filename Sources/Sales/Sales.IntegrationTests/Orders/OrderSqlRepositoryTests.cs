using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.Sales.Time;
using Xunit;

namespace MyCompany.Crm.Sales.Orders
{
    public class OrderSqlRepositoryTests : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly PriceChangesPolicy _priceChangesPolicies = new FakePriceChangesPolicy();
        private readonly SystemClock _clock = new SystemClock();
        private readonly IServiceProvider _serviceProvider;

        private string _repositoryImplementation;
        private IServiceScope _scope;
        private OrderRepository _repository;
        private Order _order;

        public OrderSqlRepositoryTests(WebApplicationFactory<Startup> appFactory) => _serviceProvider = appFactory
            .WithWebHostBuilder(builder => builder
                .ConfigureServices(services => services
                    .AddScoped<OrderSqlRepository.TablesFromSnapshot>()
                    .AddScoped<OrderSqlRepository.TablesFromEvents>()
                    .AddScoped<OrderSqlRepository.DocumentFromSnapshot>()
                    .AddScoped<OrderSqlRepository.DocumentFromEvents>()
                    .AddScoped<OrderSqlRepository.EventsSourcing>()))
            .Services;

        [Theory]
        [InlineData(nameof(OrderSqlRepository.TablesFromSnapshot))]
        [InlineData(nameof(OrderSqlRepository.TablesFromEvents))]
        [InlineData(nameof(OrderSqlRepository.DocumentFromSnapshot))]
        [InlineData(nameof(OrderSqlRepository.DocumentFromEvents))]
        [InlineData(nameof(OrderSqlRepository.EventsSourcing), Skip = "Not implemented")]
        public async Task RestoredOrderIsEqualToOriginal(string repositoryImplementation)
        {
            _repositoryImplementation = repositoryImplementation;
            var (productAmount1, productAmount2, productAmount3) = CreateProductAmounts();
            var offer1 = CreateOfferFor(productAmount1, productAmount2);
            var offer2 = CreateOfferFor(productAmount1, productAmount2, productAmount3);
            var now = _clock.Now;
            
            await TestRestoreAfter(() => Order.New());
            await TestRestoreAfter(order => order.Add(productAmount1));
            await TestRestoreAfter(order => order.Add(productAmount2));
            await TestRestoreAfter(order => order.ConfirmPrices(offer1, now.AddDays(2), now, _priceChangesPolicies));
            await TestRestoreAfter(order => order.Add(productAmount3));
            await TestRestoreAfter(order =>
                order.ConfirmPrices(offer2, now.AddDays(3), now.AddDays(1), _priceChangesPolicies));
            await TestRestoreAfter(order => order.Place(now.AddDays(2)));
            await TestRestoreAfter(() => Order.FromOffer(offer2));
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

        private async Task TestRestoreAfter(Func<Order> action)
        {
            _order = action();
            await TestRestore();
        }

        private async Task TestRestoreAfter(Action<Order> action)
        {
            action(_order);
            await TestRestore();
        }

        private async Task TestRestore()
        {
            await Save(_order);
            var restoredOrder = await GetBy(_order.Id);
            restoredOrder.Should().Be(_order);
            _order = restoredOrder;
        }

        private Task<Order> GetBy(OrderId id)
        {
            CreateScope();
            return _repository.GetBy(id);
        }

        private Task Save(Order order)
        {
            if (_repository is null)
                CreateScope();
            return _repository.Save(order);
        }

        private void CreateScope()
        {
            _scope?.Dispose();
            _scope = _serviceProvider.CreateScope();
            _repository = _repositoryImplementation switch
            {
                nameof(OrderSqlRepository.TablesFromSnapshot) => _scope.ServiceProvider
                    .GetService<OrderSqlRepository.TablesFromSnapshot>(),
                nameof(OrderSqlRepository.TablesFromEvents) => _scope.ServiceProvider
                    .GetService<OrderSqlRepository.TablesFromEvents>(),
                nameof(OrderSqlRepository.DocumentFromSnapshot) => _scope.ServiceProvider
                    .GetService<OrderSqlRepository.DocumentFromSnapshot>(),
                nameof(OrderSqlRepository.DocumentFromEvents) => _scope.ServiceProvider
                    .GetService<OrderSqlRepository.DocumentFromEvents>(),
                nameof(OrderSqlRepository.EventsSourcing) => _scope.ServiceProvider
                    .GetService<OrderSqlRepository.EventsSourcing>(),
                _ => throw new ArgumentOutOfRangeException(nameof(_repositoryImplementation),
                    _repositoryImplementation,
                    null)
            };
        }

        public void Dispose() => _scope?.Dispose();
    }
}