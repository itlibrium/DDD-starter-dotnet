using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.EntityFramework;
using static MyCompany.ECommerce.Nuke.DockerCompose.DockerComposeTargets;
using static MyCompany.ECommerce.Nuke.Postgres.PostgresTasks;
using static MyCompany.ECommerce.Nuke.Paths;

namespace MyCompany.ECommerce.Nuke.DotNet;

public static class EntityFrameworkTargets
{
    private const string StartupProject = "Monolith.Startup/Monolith.Startup.csproj";
    // TODO: Automatic detecting all projects with DbContexts.
    private static readonly (string Project, string Name)[] DbContexts =
    {
        ("Sales/Sales.Adapters/Sales.Adapters.csproj", "SalesDbContext"),
        ("Contacts/Contacts/Contacts.csproj", "ContactsDbContext")
    };

    public static Target ApplyMigrationsOnLocalDockerInfrastructure => _ => _
        .DependsOn(StartLocalDockerInfrastructure)
        .Executes(() =>
        {
            // TODO: Use connection string from main configuration.
            WaitForDatabase(Settings.Postgres.ConnectionString);
            foreach (var (project, dbContextName) in DbContexts)
            {
                EntityFrameworkTasks.EntityFrameworkDatabaseUpdate(settings => settings
                    .SetProcessWorkingDirectory(SourcesDirectory)
                    .SetStartupProject(StartupProject)
                    .SetProject(project)
                    .SetContext(dbContextName));
            }
        });
}