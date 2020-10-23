using System.Reflection;
using Marten;
using Marten.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Marten;

namespace MyCompany.Crm.DI.Modules
{
    internal static class Sales
    {
        private static readonly Assembly SalesDomain = typeof(SalesDomainAssemblyInfo).Assembly;
        private static readonly Assembly SalesUseCases = typeof(SalesUseCasesAssemblyInfo).Assembly;
        private static readonly Assembly SalesAdaptersSql = typeof(SalesAdaptersSqlAssemblyInfo).Assembly;
        private static readonly Assembly SalesAdaptersKafka = typeof(SalesAdaptersKafkaAssemblyInfo).Assembly;

        public static IServiceCollection AddSalesModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Sales")));
            services.AddMarten(options =>
                {
                    options.Connection(configuration.GetConnectionString("Sales"));
                    options.Events.StreamIdentity = StreamIdentity.AsGuid;
                    foreach (var (type, name) in OrderSqlRepository.EventsSourcing.Events)
                    {
                        options.Events.AddEventType(type);
                        options.Events.EventMappingFor(type).EventTypeName = name;
                    }
                    options.Schema.For<Order.Snapshot>().UseOptimisticConcurrency(true);
                    options.Schema.For<OrderSqlRepository.DocumentFromEvents.OrderDoc>().UseOptimisticConcurrency(true);
                })
                .BuildSessionsWith<LightweightSessionFactory>()
                .InitializeStore();
            services.AddScoped<OrderRepository, OrderSqlRepository.TablesFromEvents>();
            services.AddDbContextPool<SalesCrudDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Sales")));
            services.AddScoped<SalesCrudDao, SalesCrudEfDao>();
            services.AddDbContextPool<SalesKafkaOutboxDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Sales")));
            services.AddScoped<SalesKafkaOutboxWriter>();
            services.AddScoped<OrderReadModelDao, OrderReadModelSqlDao>();
            services.AddMessageOutboxes(SalesAdaptersKafka);
            services.AddStatelessComponents(SalesDomain, SalesUseCases, SalesAdaptersSql);
            return services;
        }
    }
}