using System.Reflection;
using System.Text.Json.Serialization;
using Marten;
using Marten.Events;
using Marten.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.ECommerce.Sales;
using MyCompany.ECommerce.Sales.Database.Sql.EF;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Orders.PriceChanges;
using MyCompany.ECommerce.TechnicalStuff.Json.Json;
using MyCompany.ECommerce.TechnicalStuff.Marten;
using MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres;
using RepoDb;
using DbOrder = MyCompany.ECommerce.Sales.Database.Sql.Documents.DbOrder;

namespace MyCompany.ECommerce.DI.Modules
{
    internal static class Sales
    {
        private static readonly Assembly SalesDeepModel = typeof(SalesDeepModelLayerInfo).Assembly;
        private static readonly Assembly SalesProcessModel = typeof(SalesProcessModelLayerInfo).Assembly;
        private static readonly Assembly SalesAdapters = typeof(SalesAdaptersLayerInfo).Assembly;

        public static IServiceCollection AddSalesModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Main");
            GlobalConfiguration.Setup().UsePostgreSql();
            // TODO: Same connection provider for all data access libraries (EF, Marten, RepoDB) 
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable("__Sales_Migrations")));
            services.AddMarten(options =>
                {
                    options.Connection(connectionString);
                    var serializer = new SystemTextJsonSerializer();
                    serializer.Customize(serializerOptions =>
                    {
                        var converters = serializerOptions.Converters;
                        serializerOptions.PropertyNameCaseInsensitive = true;
                        converters.Add(new JsonStringEnumConverter());
                        converters.Add(new ValueObjectJsonConverterFactory());
                    });
                    options.Serializer(serializer);
                    options.Events.StreamIdentity = StreamIdentity.AsGuid;
                    foreach (var (type, name) in OrderSqlRepository.EventsSourcing.Events)
                    {
                        options.Events.AddEventType(type);
                        options.Events.MapEventType(type, name);
                    }
                    options.Schema.For<DbOrder>().UseOptimisticConcurrency(true);
                })
                .BuildSessionsWith<LightweightSessionFactory>()
                .InitializeWith();
            services.AddScoped<SalesCrudOperations, SalesCrudEfDao>();
            services.AddMessageOutboxes(SalesAdapters);
            services.AddScoped<OrderEventsOutbox, FakeOrderEventOutbox>();
            services.AddScoped<PostgresOutboxRepository>();
            services.AddStatelessComponentsFrom(SalesDeepModel, SalesProcessModel, SalesAdapters);
            services.AddScoped<Order.Repository, OrderSqlRepository.Raw>();
            services.AddScoped<AllowAnyPriceChanges>();
            services.AddScoped<AllowPriceChangesIfTotalPriceIsLower>();
            return services;
        }
    }
}