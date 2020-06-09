using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static MyCompany.Crm.Nuke.Paths;

namespace MyCompany.Crm.Nuke.DotNet
{
    public class DotNetTargets : NukeBuild
    {
        public static Target Clean => _ => _
            .Before(Restore)
            .Executes(() =>
            {
                SourcesDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                EnsureCleanDirectory(ArtifactsDirectory);
            });

        public static Target Restore => _ => _
            .Executes(() =>
            {
                DotNetRestore(s => s
                    .SetProjectFile(Build.Solution));
            });

        public static Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                DotNetBuild(s => s
                    .SetProjectFile(Build.Solution)
                    .SetConfiguration(Build.BuildConfiguration)
                    // .SetAssemblyVersion(GitVersion.AssemblySemVer)
                    // .SetFileVersion(GitVersion.AssemblySemFileVer)
                    // .SetInformationalVersion(GitVersion.InformationalVersion)
                    .EnableNoRestore());
            });
    }
}