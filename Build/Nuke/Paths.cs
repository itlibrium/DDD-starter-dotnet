using Nuke.Common;
using Nuke.Common.IO;

namespace MyCompany.ECommerce.Nuke
{
    public static class Paths
    {
        public static readonly AbsolutePath SourcesDirectory = NukeBuild.RootDirectory / "Sources";
        public static readonly AbsolutePath NukeDirectory = NukeBuild.RootDirectory / "Build" / "Nuke";
        
        public static readonly AbsolutePath ArtifactsDirectory = NukeDirectory / "Artifacts";
        public static readonly AbsolutePath BinDirectory = ArtifactsDirectory / "Bin";
        
        public static readonly AbsolutePath StartupProjectFile = SourcesDirectory / "Startup" / "Startup.csproj";
    }
}