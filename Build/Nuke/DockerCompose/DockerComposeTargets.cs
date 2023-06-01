using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.DockerCompose;
using static MyCompany.ECommerce.Nuke.Paths;
using static MyCompany.ECommerce.Nuke.Environment;
using static MyCompany.ECommerce.Nuke.Certs.CertsTargets;
using static MyCompany.ECommerce.Nuke.Elastic.ElasticTargets;

namespace MyCompany.ECommerce.Nuke.DockerCompose
{
    public static class DockerComposeTargets
    {
        private static readonly AbsolutePath ComposeDirectory = NukeDirectory / "DockerCompose";

        public static Target StartLocalDockerInfrastructure => _ => _
            .DependsOn(PrepareCertificates, CreateElasticUsers)
            .Executes(() =>
            {
                DockerComposeTasks.Up(settings => settings
                    .SetFile(GetInfrastructureComposeFiles())
                    .Apply(upSettings => SetInfrastructureEnvironmentVariables(upSettings))
                    .SetDetach(true));
                WriteLogsInfo();
            });

        public static Target StopLocalDockerInfrastructure => _ => _
            .Executes(() =>
            {
                DockerComposeTasks.Down(settings => settings
                    .SetFile(GetInfrastructureComposeFiles())
                    .Apply(SetInfrastructureEnvironmentVariables)
                );
            });

        public static Target CleanLocalDockerInfrastructure => _ => _
            .DependsOn(
                StopLocalDockerInfrastructure,
                CleanCertificates,
                CleanElasticUsers)
            .Executes(() =>
            {
                DockerTasks.DockerVolumePrune(settings => settings
                    .SetForce(true));
            });

        public static Target DisplayLocalDockerInfrastructureLogs => _ => _
            .Executes(() =>
            {
                DockerComposeTasks.Logs(settings => settings
                    .SetFile(GetInfrastructureComposeFiles())
                    .Apply(SetInfrastructureEnvironmentVariables)
                    .SetFollow(true));
            });

        private static IEnumerable<string> GetInfrastructureComposeFiles([CallerMemberName] string targetName = null)
        {
            yield return ComposeDirectory / "infrastructure-compose.yml";
            if (EnvironmentIs(Development))
            {
                var overrideFilePath = GetOverrideFileNameFor(Development);
                if (overrideFilePath.FileExists())
                    yield return overrideFilePath;
            }
            else if (EnvironmentIs(Test))
            {
                var overrideFilePath = GetOverrideFileNameFor(Test);
                if (overrideFilePath.FileExists())
                    yield return overrideFilePath;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(Environment), Build.Environment,
                    $"Environment not supported for: {targetName}");
            }
        }

        private static AbsolutePath GetOverrideFileNameFor(Environment environment) =>
            ComposeDirectory / $"infrastructure-compose.{((string)environment).ToLower()}.yml";

        private static T SetInfrastructureEnvironmentVariables<T>(T settings)
            where T : DockerComposeSettings => settings
            .SetProcessEnvironmentVariable("ES_VERSION", Settings.Elastic.ElasticsearchVersion)
            .SetProcessEnvironmentVariable("ES_CONFIG_DIR", Settings.Elastic.ElasticsearchConfigDirectory)
            .SetProcessEnvironmentVariable("KIBANA_VERSION", Settings.Elastic.KibanaVersion)
            .SetProcessEnvironmentVariable("KIBANA_CONFIG_DIR", Settings.Elastic.KibanaConfigDirectory)
            .SetProcessEnvironmentVariable("ES_KIBANA01_USER", Settings.Elastic.Kibana01UserName)
            .SetProcessEnvironmentVariable("ES_KIBANA01_PASSWORD", Settings.Elastic.Kibana01UserPassword)
            .SetProcessEnvironmentVariable("KIBANA_ENCRYPTIONKEY", Settings.Elastic.KibanaEncryptionKey)
            .SetProcessEnvironmentVariable("ES_USERS_DIR", UsersDirectory)
            .SetProcessEnvironmentVariable("CERTS_DIR", CertsDirectory);

        private static void WriteLogsInfo()
        {
            var previousForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Use \"nuke {nameof(DisplayLocalDockerInfrastructureLogs)}\" to see the logs.");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.ForegroundColor = previousForegroundColor;
        }
    }
}