using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.DI;
using MyCompany.Crm.DI.Modules;
using MyCompany.Crm.TechnicalStuff.Api;

namespace MyCompany.Crm
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureApiServices(services);
            ConfigureMessagingServices(services);
            ConfigureModulesServices(services);
            ConfigureDecorators(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseOpenApiWithUi();
        }
        
        private static void ConfigureApiServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddControllersAsServices() // to check container registrations at startup
                .AddXmlSerializerFormatters(); // to show content negotiation
            // TODO: additional media types in Open API documents
            
            // Versioning whole API is done by path segment (manually in Route attribute).
            // Each endpoint in each API version can also be versioned independently by query parameter.
            services.AddEndpointVersioningByQueryParameter();
            services.AddApiVersionDocument(options =>
            {
                options.PathPrefix = "api";
                options.Title = "Old API";
                options.Description = @"
It's the old API that's supported only for backward compatibility with some clients.
Use REST API instead whenever possible.";
                options.UseEndpointVersioning = false;
            });
            services.AddApiVersionDocument(options =>
            {
                options.PathPrefix = "rest";
                options.Title = "REST API";
                options.UseEndpointVersioning = true;
            });
        }

        private void ConfigureMessagingServices(IServiceCollection services)
        {
            services.AddOutboxesRegistry();
            services.AddKafka(_configuration);
        }
        
        private void ConfigureModulesServices(IServiceCollection services)
        {
            services.AddSalesModule(_configuration);
            services.AddContactsModule(_configuration);
        }
        
        private static void ConfigureDecorators(IServiceCollection services)
        {
            services.DecorateCommandHandlers();
        }
    }
}