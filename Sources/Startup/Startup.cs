using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Crm.Contacts;
using MyCompany.Crm.Contacts.Database;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Database;

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
                .UseNpgsql(_configuration.GetConnectionString("Contacts"), sqlOptions => sqlOptions
                    .MigrationsAssembly(ContactsDatabaseAssemblyInfo.Name)
                    .MigrationsHistoryTable("__ContactsCrudDbContext_Migrations")));
            services.AddScoped<ContactsCrudDao, ContactsEfCrudDao>();
            services.AddDbContextPool<SalesDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Sales"), sqlOptions => sqlOptions
                    .MigrationsAssembly(SalesDatabaseAssemblyInfo.Name)
                    .MigrationsHistoryTable("__SalesDbContext_Migrations")));
            services.AddDbContextPool<SalesCrudDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Sales"), sqlOptions => sqlOptions
                    .MigrationsAssembly(SalesDatabaseAssemblyInfo.Name)
                    .MigrationsHistoryTable("__SalesCrudDbContext_Migrations")));
            services.AddScoped<SalesCrudDao, SalesEfCrudDao>();
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