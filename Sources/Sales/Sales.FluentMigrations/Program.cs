﻿using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P3Model.Annotations;

[assembly: ExcludeFromDocs]

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, false)
    .AddJsonFile($"appsettings.{environmentName}.json", true, false)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();
var mainConnectionString = configuration.GetConnectionString("Crm");

var serviceProvider = new ServiceCollection()
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(mainConnectionString)
        .ScanIn(typeof(MyCompany.ECommerce.Sales.FluentMigrations.Program).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .BuildServiceProvider(false);

using var scope = serviceProvider.CreateScope();
var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();

namespace MyCompany.ECommerce.Sales.FluentMigrations
{
    public partial class Program { }
}
