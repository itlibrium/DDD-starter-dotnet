using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;

namespace MyCompany.ECommerce.Nuke;

[UnsetVisualStudioEnvironmentVariables]
public partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    [Solution]
    public static Solution Solution { get; private set; }
        
    // [GitRepository] readonly GitRepository GitRepository;
    // [GitVersion] readonly GitVersion GitVersion;
}