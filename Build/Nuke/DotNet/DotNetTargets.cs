using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static MyCompany.ECommerce.Nuke.Build;
using static MyCompany.ECommerce.Nuke.Certs.CertsTargets;
using static MyCompany.ECommerce.Nuke.DockerCompose.DockerComposeTargets;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static MyCompany.ECommerce.Nuke.DotNet.EntityFrameworkTargets;
using static MyCompany.ECommerce.Nuke.Elastic.ElasticTargets;
using static MyCompany.ECommerce.Nuke.Paths;

namespace MyCompany.ECommerce.Nuke.DotNet
{
    public static class DotNetTargets
    {
        private static readonly ISet<string> RootProjects = new HashSet<string>
        {
            "Monolith.Startup",
            "Sales.FluentMigrations"
        };

        public static Target CleanBin => _ => _
            .Before(Restore)
            .Executes(() =>
            {
                SourcesDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                DeleteDirectory(BinDirectory);
            });

        public static Target Restore => _ => _
            .Executes(() =>
            {
                DotNetRestore(s => s
                    .SetProjectFile(Solution));
            });

        public static Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                RootProjects.ForEach(projectName =>
                {
                    var project = Solution.GetProject(projectName);
                    if (project is null)
                        throw new InvalidOperationException($"Compilation root project: {projectName} is missing");
                    DotNetBuild(s => s
                        .SetProjectFile(project.Path)
                        .SetConfiguration(BuildConfiguration)
                        .SetOutputDirectory(BinDirectory / project.Name)
                        // .SetAssemblyVersion(GitVersion.AssemblySemVer)
                        // .SetFileVersion(GitVersion.AssemblySemFileVer)
                        // .SetInformationalVersion(GitVersion.InformationalVersion)
                        .EnableNoRestore());
                });
            });

        public static Target RunIntegrationTestsOnLocalDockerInfrastructure => _ => _
            .DependsOn(
                CleanBin,
                Compile,
                StartLocalDockerInfrastructure,
                ApplyMigrationsOnLocalDockerInfrastructure)
            .Triggers(CleanLocalDockerInfrastructure)
            .Before(
                StopLocalDockerInfrastructure,
                CleanCertificates,
                CleanElasticUsers)
            .Executes(() =>
            {
                Solution.AllProjects
                    .Where(project => project.Name.EndsWith(".IntegrationTests"))
                    .ForEach(project => DotNetTest(settings => settings
                        .SetProjectFile(project.Path)));
            });
    }
}