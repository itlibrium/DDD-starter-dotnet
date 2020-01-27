using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Contacts;
using MyCompany.Crm.Contacts.Database;
using MyCompany.Crm.Sales;
using MyCompany.Crm.Sales.Database;
using SimpleInjector;

namespace MyCompany.Crm
{
    public class Startup
    {
        private readonly Container _container = new Container();
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;
        private readonly IReadOnlyCollection<ContainerOverride> _containerOverrides;

        public Startup(IConfiguration configuration, IHostingEnvironment environment,
            IEnumerable<ContainerOverride> containerOverrides)
        {
            _configuration = configuration;
            _environment = environment;
            _containerOverrides = containerOverrides.ToList().AsReadOnly();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContextPool<ContactsCrudDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Contacts"), sqlOptions => sqlOptions
                    .MigrationsAssembly(ContactsDatabaseAssemblyInfo.Name)
                    .MigrationsHistoryTable("__ContactsCrudDbContext_Migrations")));
            services.AddDbContextPool<SalesCrudDbContext>(options => options
                .UseNpgsql(_configuration.GetConnectionString("Sales"), sqlOptions => sqlOptions
                    .MigrationsAssembly(SalesDatabaseAssemblyInfo.Name)
                    .MigrationsHistoryTable("__SalesCrudDbContext_Migrations")));
            services.AddSimpleInjector(_container, options => options
                .DisableAutoCrossWire()
                .CrossWire<ContactsCrudDbContext>()
                .CrossWire<SalesCrudDbContext>()
                .AddAspNetCore()
                .AddControllerActivation());
            var serviceProvider = services.BuildServiceProvider(true);
            serviceProvider.UseSimpleInjector(_container);
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            ContainerConfig.Apply(_container, _configuration, _environment);
            if (_containerOverrides.Count != 0)
            {
                if (_environment.IsProduction())
                    throw new InvalidOperationException("Can't override container configuration in production");
                _container.Options.AllowOverridingRegistrations = true;
                foreach (var containerOverride in _containerOverrides)
                    containerOverride.Apply(_container, _configuration, _environment);
            }
            _container.Verify();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}