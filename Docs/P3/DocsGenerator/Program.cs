using P3Model.Annotations.Domain;
using P3Model.Parser.Configuration;

await P3
    .Product(product => product
        .UseName("MyCompany e-commerce"))
    .Repositories(repositories => repositories
        .Use("."))
    .Analyzers(analyzers => analyzers
        .UseDefaults(options => options
            .TreatNamespacesAsDomainModules(namespaces => namespaces
                .OnlyFromAssembliesAnnotatedWith<DomainModelAttribute>()
                .RemoveRootNamespace("MyCompany.ECommerce"))))
    .OutputFormat(formatters => formatters
        .UseMermaid(options => options
            .Directory("Docs/P3/MermaidOutput")
            .UseDefaultPages())
        .UseJson(options => options
            .File("Docs/P3/JsonOutput/model.json")))
    .Analyze();