using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.EntityFramework;
using static MyCompany.Crm.Nuke.DockerCompose.DockerComposeTargets;
using static MyCompany.Crm.Nuke.Postgres.PostgresTasks;
using static MyCompany.Crm.Nuke.Paths;

namespace MyCompany.Crm.Nuke.DotNet
{
    public static class EntityFrameworkTargets
    {
        // TODO: Automatic detecting all *.Database projects and DbContexts.
        private static readonly (string WorkingDir, string Name)[] DbContexts =
        {
            ("Sales/Sales.Database", "SalesDbContext"),
            ("Contacts/Contacts.Database", "ContactsCrudDbContext")
        };

        public static Target ApplyMigrationsOnLocalDockerInfrastructure => _ => _
            .DependsOn(StartLocalDockerInfrastructure)
            .Executes(() =>
            {
                WaitForDatabase(Settings.Postgres.MigrationConnectionString);
                foreach (var (workingDir, dbContextName) in DbContexts)
                {
                    EntityFrameworkTasks.EntityFrameworkDatabaseUpdate(settings => settings
                        .SetProcessWorkingDirectory(SourcesDirectory / workingDir)
                        .SetContext(dbContextName));
                }
            });
    }
}