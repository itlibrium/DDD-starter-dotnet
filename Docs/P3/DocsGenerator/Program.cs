using P3Model.Parser.Configuration;
using P3Model.Parser.OutputFormatting.Json.Configuration;
using P3Model.Parser.OutputFormatting.Mermaid.Configuration;
using Serilog.Events;

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
        .UseMermaid(options => options
            .Directory("Docs/P3/MermaidOutput")
            .UseDefaultPages())
        .UseJson(options => options
            .File("Docs/P3/JsonOutput/model.json")))
    .LogLevel(LogEventLevel.Information)
    .Analyze();