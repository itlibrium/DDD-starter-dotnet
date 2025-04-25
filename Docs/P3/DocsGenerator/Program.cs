using P3Model.Annotations;
using P3Model.Parser.Configuration;
using P3Model.Parser.OutputFormatting.Json.Configuration;
using Serilog.Events;

[assembly: ExcludeFromDocs]

await P3
    .Product(product => product
        .UseName("MyCompany e-commerce"))
    .Repositories(repositories => repositories
        .Use("."))
    .Analyzers(analyzers => analyzers
        .UseDefaults(options => options
            .TreatNamespacesAsDomainModules(namespaces => namespaces
                .SkipNamespacePart("ECommerce", "MyCompany"))))
    .OutputFormat(formatters => formatters
        .UseJson(options => options
            .File("Docs/P3/JsonOutput/model.json")))
    .LogLevel(LogEventLevel.Information)
    .Analyze();