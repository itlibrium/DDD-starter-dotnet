using Nuke.Common;
using Nuke.Common.IO;

namespace MyCompany.Crm.Nuke
{
    public static class Paths
    {
        public static readonly AbsolutePath SourcesDirectory = NukeBuild.RootDirectory / "Sources";
        public static readonly AbsolutePath BuildDirectory = NukeBuild.RootDirectory / "Build" / "Nuke";
        public static readonly AbsolutePath ArtifactsDirectory = BuildDirectory / "Artifacts";
    }
}