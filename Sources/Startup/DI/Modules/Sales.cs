using System.Reflection;
using System.Text.Json.Serialization;
using Marten;
using Marten.Events;
using Marten.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Database;
using MyCompany.Crm.Sales.Database.Sql.EF;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.TechnicalStuff.Json.Json;
using MyCompany.Crm.TechnicalStuff.Marten;
using MyCompany.Crm.TechnicalStuff.Outbox.Postgres;
using RepoDb;
using DbOrder = MyCompany.Crm.Sales.Database.Sql.Documents.DbOrder;

namespace MyCompany.Crm.DI.Modules
{
    internal static class Sales
    {
        private static readonly Assembly SalesDeepModel = typeof(SalesDeepModel).Assembly;
        private static readonly Assembly SalesProcessModel = typeof(SalesProcessModelAssemblyInfo).Assembly;
        private static readonly Assembly SalesAdapters = typeof(SalesAdaptersAssemblyInfo).Assembly;

        public static IServiceCollection AddSalesModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sales");
            GlobalConfiguration.Setup().UsePostgreSql();
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable("__Sales_Migrations")));
            services.AddScoped(_ => new SalesDb(connectionString));
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
            services.AddScoped<PostgresOutboxRepository<SalesDb>>();
            services.AddStatelessComponentsFrom(SalesDeepModel, SalesProcessModel, SalesAdapters);
            services.AddScoped<OrderRepository, OrderSqlRepository.EF>();
            services.AddScoped<AllowAnyPriceChanges>();
            services.AddScoped<AllowPriceChangesIfTotalPriceIsLower>();
            return services;
        }
    }
}