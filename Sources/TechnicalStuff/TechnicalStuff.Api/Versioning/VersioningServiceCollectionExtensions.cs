using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace MyCompany.ECommerce.TechnicalStuff.Api.Versioning;

public static class VersioningServiceCollectionExtensions
{
    private const string EndpointVersionParameterName = "version";

    public static IServiceCollection AddEndpointVersioningByQueryParameter(this IServiceCollection services) =>
        services.AddApiVersioning(options =>
        {
            options.ApiVersionReader = new QueryStringApiVersionReader(EndpointVersionParameterName);
            options.AssumeDefaultVersionWhenUnspecified = false;
            options.ReportApiVersions = false;
        });

    public static IServiceCollection AddApiVersionDocument(this IServiceCollection services,
        Action<ApiVersionDocumentOptions> configure)
    {
        if (configure is null) throw new ArgumentNullException(nameof(configure));
        var options = new ApiVersionDocumentOptions();
        configure.Invoke(options);
        if (options.PathPrefix is null) throw new ArgumentNullException(nameof(options.PathPrefix));
        services.AddOpenApiDocument(settings =>
        {
            var pathPrefix = options.PathPrefix.Trim('/');
            settings.DocumentName = pathPrefix;
            settings.Version = options.UseEndpointVersioning ? "versioning per endpoint" : "no versioning";
            settings.Title = options.Title ?? pathPrefix;
            settings.Description = options.Description;
            settings.AddOperationFilter(context =>
                context.OperationDescription.Path.StartsWith($"/{pathPrefix}/"));
            if (options.UseEndpointVersioning)
                settings.OperationProcessors.Add(new EndpointVersioningProcessor(EndpointVersionParameterName));
        });
        return services;
        // TODO: better schemas naming - configuration (attributes, fluent api, etc.)
    }
}