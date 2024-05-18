using Microsoft.AspNetCore.Builder;

namespace MyCompany.ECommerce.TechnicalStuff.Api.Docs;

public static class DocsApplicationBuilderExtensions
{
    public static IApplicationBuilder UseOpenApiWithUi(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi3();
        return app;
    }
}