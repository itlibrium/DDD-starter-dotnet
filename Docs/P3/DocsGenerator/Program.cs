using Microsoft.Extensions.Configuration;
using P3Model.Parser.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .AddEnvironmentVariables()
    .Build();
var repositoryPath = configuration["RepositoryPath"] ?? $"{Environment.CurrentDirectory}/../../../../../../";
var outputPath = configuration["OutputPath"] ?? $"{Environment.CurrentDirectory}/../../../../../../Docs/P3";
await P3
    .Product(product => product
        .UseName("MyCompany e-commerce"))
    .Repositories(repositories => repositories
        .Use(repositoryPath))
    .Analyzers(analyzers => analyzers
        .UseDefaults(options => options
            .TreatNamespacesAsDomainModules(namespaces => namespaces
                .Exclude("TechnicalStuff")
                .Exclude("Infrastructure")
                .Exclude("Adapters")
                .Exclude("RestApi")
                .Exclude("OldApi")
                .Exclude("Database")
                .Exclude("FluentMigrations")
                .Exclude("DI")
                .Exclude("Nuke")
                .RemoveRootNamespace("MyCompany.ECommerce"))))
    .OutputFormat(formatters => formatters
        .UseMermaid(options => options
            .Directory($"{outputPath}/MermaidOutput")
            .UseDefaultPages())
        .UseJson(options => options
            .File($"{outputPath}/JsonOutput/model.json")))
    .Analyze();