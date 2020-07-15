using Marten;
using Marten.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.Contacts;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Marten;

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
            services.AddControllers()
                .AddControllersAsServices();
            services.AddDbContextPool<ContactsCrudDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Contacts")));
            services.AddScoped<ContactsCrudDao, ContactsCrudEfDao>();
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Sales")));
            services.AddMarten(options =>
                {
                    options.Connection(_configuration.GetConnectionString("Sales"));
                    options.Events.StreamIdentity = StreamIdentity.AsGuid;
                })
                .BuildSessionsWith<LightweightSessionFactory>()
                .InitializeStore();
            services.AddScoped<OrderRepository, OrderSqlRepository.TablesFromEvents>();
            services.AddDbContextPool<SalesCrudDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Sales")));
            services.AddScoped<SalesCrudDao, SalesCrudEfDao>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}