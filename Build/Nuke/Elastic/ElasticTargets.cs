using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Docker;
using static Nuke.Common.IO.FileSystemTasks;
using static MyCompany.ECommerce.Nuke.Paths;

namespace MyCompany.ECommerce.Nuke.Elastic;

public static class ElasticTargets
{
    public static readonly AbsolutePath UsersDirectory = ArtifactsDirectory / "Elastic" / "Users";
    private static readonly AbsolutePath ElasticDirectory = NukeDirectory / "Elastic";
    private static readonly AbsolutePath CreateUsersScript = ElasticDirectory / "create_elastic_users.sh";
        
    public static Target CreateElasticUsers => _ => _
        .Executes(() =>
        {
            EnsureExistingDirectory(UsersDirectory);
            return DockerTasks.DockerRun(c => c
                .SetImage($"docker.elastic.co/elasticsearch/elasticsearch:{Settings.Elastic.ElasticsearchVersion}")
                .SetCommand("/bin/bash")
                .SetArgs("/input/script.sh")
                .SetUser(Build.ExecutingUser)
                .SetVolume(
                    $"{CreateUsersScript}:/input/script.sh",
                    $"{UsersDirectory}:/output")
                .SetEnv(
                    $"\"ES_SUPERUSER={Settings.Elastic.SuperUserName}\"",
                    $"\"ES_SUPERUSER_PASSWORD={Settings.Elastic.SuperUserPassword}\"",
                    $"\"ES_KIBANA01_USER={Settings.Elastic.Kibana01UserName}\"",
                    $"\"ES_KIBANA01_PASSWORD={Settings.Elastic.Kibana01UserPassword}\"",
                    $"\"ES_CONFIG_DIR={Settings.Elastic.ElasticsearchConfigDirectory}\"")
                .SetRm(true));
        });

    public static Target CleanElasticUsers => _ => _
        .Executes(() =>
        {
            DeleteDirectory(UsersDirectory);
        });
}