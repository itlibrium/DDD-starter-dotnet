using System;
using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Nuke.DockerCompose;
using static Nuke.Common.IO.FileSystemTasks;
using static MyCompany.Crm.Nuke.Paths;
using static MyCompany.Crm.Nuke.Environment;
using static MyCompany.Crm.Nuke.Certs.CertsTargets;
using static MyCompany.Crm.Nuke.Elastic.ElasticTargets;

namespace MyCompany.Crm.Nuke.DockerCompose
{
    public static class DockerComposeTargets
    {
        private static readonly AbsolutePath ComposeDirectory = NukeDirectory / "DockerCompose";

        public static Target StartLocalDockerInfrastructure => _ => _
            .DependsOn(PrepareCertificates, CreateElasticUsers)
            .Executes(() =>
            {
                DockerComposeTasks.Up(settings => settings
                    .SetFile(InfrastructureComposeFiles)
                    .Apply(SetInfrastructureEnvironmentVariables)
                    .SetDetach(true));
            });

        public static Target StopLocalDockerInfrastructure => _ => _
            .Executes(() =>
            {
                DockerComposeTasks.Down(settings => settings
                    .SetFile(InfrastructureComposeFiles)
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

        private static IEnumerable<string> InfrastructureComposeFiles
        {
            get
            {
                yield return ComposeDirectory / "infrastructure-compose.yml";
                if (EnvironmentIs(Development))
                {
                    var overrideFilePath = GetOverrideFileNameFor(Development);
                    if (FileExists(overrideFilePath))
                        yield return overrideFilePath;
                }
                else if (EnvironmentIs(Test))
                {
                    var overrideFilePath = GetOverrideFileNameFor(Test);
                    if (FileExists(overrideFilePath))
                        yield return overrideFilePath;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Environment), Build.Environment,
                        $"Environment not supported for {/*nameof(Build.StartDockerComposeInfrastructure)*/""}");
                }
            }
        }

        private static AbsolutePath GetOverrideFileNameFor(Environment environment) =>
            ComposeDirectory / $"infrastructure-compose.{((string) environment).ToLower()}.yml";

        private static T SetInfrastructureEnvironmentVariables<T>(T settings) where T : DockerComposeSettings =>
            settings
                .SetEnvironmentVariable("ES_VERSION", Settings.Elastic.ElasticsearchVersion)
                .SetEnvironmentVariable("ES_CONFIG_DIR", Settings.Elastic.ElasticsearchConfigDirectory)
                .SetEnvironmentVariable("KIBANA_VERSION", Settings.Elastic.KibanaVersion)
                .SetEnvironmentVariable("KIBANA_CONFIG_DIR", Settings.Elastic.KibanaConfigDirectory)
                .SetEnvironmentVariable("ES_KIBANA01_USER", Settings.Elastic.Kibana01UserName)
                .SetEnvironmentVariable("ES_KIBANA01_PASSWORD", Settings.Elastic.Kibana01UserPassword)
                .SetEnvironmentVariable("KIBANA_ENCRYPTIONKEY", Settings.Elastic.KibanaEncryptionKey)
                .SetEnvironmentVariable("ES_USERS_DIR", UsersDirectory)
                .SetEnvironmentVariable("CERTS_DIR", CertsDirectory);
    }
}