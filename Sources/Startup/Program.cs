using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.ECommerce.DI;
using MyCompany.ECommerce.DI.Modules;
using MyCompany.ECommerce.Infrastructure;
using MyCompany.ECommerce.Sales;
using MyCompany.ECommerce.TechnicalStuff.Api.Docs;
using MyCompany.ECommerce.TechnicalStuff.Api.Versioning;
using MyCompany.ECommerce.TechnicalStuff.Json.Json;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using P3Model.Annotations.Technology;

[assembly: DeployableUnit("ecommerce-monolith")]
[assembly: Tier("Application")]

var builder = WebApplication.CreateBuilder(args);
ConfigureSerialization();
ConfigureApiServices();
ConfigureDatabases();
ConfigureMessagingServices();
ConfigureModulesServices();
ConfigureDecorators();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseOpenApiWithUi();
app.Run();

void ConfigureSerialization()
{
    builder.Services.Configure<JsonOptions>(options =>
    {
        var converters = options.SerializerOptions.Converters;
        options.SerializerOptions.PropertyNameCaseInsensitive = true;
        converters.Add(new JsonStringEnumConverter());
        converters.Add(new ValueObjectJsonConverterFactory());
    });
}

void ConfigureApiServices()
{
    builder.Services.AddControllers();
    // TODO: additional media types in Open API documents

    // Versioning whole API is done by path segment (manually in Route attribute).
    // Each endpoint in each API version can also be versioned independently by query parameter.
    builder.Services.AddEndpointVersioningByQueryParameter();
    builder.Services.AddApiVersionDocument(options =>
    {
        options.PathPrefix = "api";
        options.Title = "Old API";
        options.Description = @"
It's the old API that's supported only for backward compatibility with some clients.
Use REST API instead whenever possible.";
        options.UseEndpointVersioning = false;
    });
    builder.Services.AddApiVersionDocument(options =>
    {
        options.PathPrefix = "rest";
        options.Title = "REST API";
        options.UseEndpointVersioning = true;
    });
}

void ConfigureDatabases()
{
    var connectionString = builder.Configuration.GetConnectionString("Main");
    builder.Services.AddScoped<MainDb>(_ => new CrmDb(connectionString));
}

void ConfigureMessagingServices()
{
    builder.Services.AddOutboxesRegistry();
    builder.Services.AddKafka(builder.Configuration);
    builder.Services.AddSingleton<FakeMessageBroker>();
    builder.Services.AddHostedService<FakeMessageConsumer>();
}

void ConfigureModulesServices()
{
    builder.Services.AddSalesModule(builder.Configuration);
    builder.Services.AddContactsModule(builder.Configuration);
}

void ConfigureDecorators()
{
    builder.Services.DecorateCommandHandlers();
}

namespace MyCompany.ECommerce
{
    public partial class Program { }
}