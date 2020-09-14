using Microsoft.AspNetCore.Builder;

namespace MyCompany.Crm.TechnicalStuff.Api
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiWithUi(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
            return app;
        }
    }
}