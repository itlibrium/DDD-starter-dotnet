using System.Reflection;
using Marten;
using Marten.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.TechnicalStuff.Marten;
using MyCompany.Crm.TechnicalStuff.Outbox.Postgres;

namespace MyCompany.Crm.DI.Modules
{
    internal static class Sales
    {
        private static readonly Assembly SalesDeepModel = typeof(SalesDeepModelAssemblyInfo).Assembly;
        private static readonly Assembly SalesProcessModel = typeof(SalesProcessModelAssemblyInfo).Assembly;
        private static readonly Assembly SalesAdapters = typeof(SalesAdaptersAssemblyInfo).Assembly;
        
        public static IServiceCollection AddSalesModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sales");
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(connectionString));
            services.AddSingleton(new SalesDb(connectionString));
            services.AddMarten(options =>
                {
                    options.Connection(connectionString);
                    options.Events.StreamIdentity = StreamIdentity.AsGuid;
                    foreach (var (type, name) in OrderSqlRepository.EventsSourcing.Events)
                    {
                        options.Events.AddEventType(type);
                        options.Events.MapEventType(type, name);
                    }
                    options.Schema.For<Order.Snapshot>().UseOptimisticConcurrency(true);
                    options.Schema.For<OrderSqlRepository.DocumentFromEvents.OrderDoc>().UseOptimisticConcurrency(true);
                })
                .BuildSessionsWith<LightweightSessionFactory>()
                .InitializeStore();
            services.AddScoped<SalesCrudOperations, SalesCrudEfDao>();
            services.AddMessageOutboxes(SalesAdapters);
            services.AddScoped<OrderEventsOutbox, FakeOrderEventOutbox>();
            services.AddScoped<PostgresOutboxRepository<SalesDb>>();
            services.AddStatelessComponentsFrom(SalesDeepModel, SalesProcessModel, SalesAdapters);
            services.AddScoped<OrderRepository, OrderSqlRepository.TablesFromEvents>();
            services.AddScoped<AllowAnyPriceChanges>();
            services.AddScoped<AllowPriceChangesIfTotalPriceIsLower>();
            return services;
        }
    }
}