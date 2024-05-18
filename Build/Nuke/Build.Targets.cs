using JetBrains.Annotations;
using MyCompany.ECommerce.Nuke.Certs;
using MyCompany.ECommerce.Nuke.DockerCompose;
using MyCompany.ECommerce.Nuke.DotNet;
using MyCompany.ECommerce.Nuke.Elastic;
using Nuke.Common;

namespace MyCompany.ECommerce.Nuke;

public partial class Build
{
    [PublicAPI]
    public Target CleanBin => DotNetTargets.CleanBin;

    [PublicAPI]
    public Target Restore => DotNetTargets.Restore;

    [PublicAPI]
    public Target Compile => DotNetTargets.Compile;

    [PublicAPI]
    public Target RunIntegrationTestsOnLocalDockerInfrastructure =>
        DotNetTargets.RunIntegrationTestsOnLocalDockerInfrastructure;

    [PublicAPI]
    public Target ApplyMigrationsOnLocalDockerInfrastructure =>
        EntityFrameworkTargets.ApplyMigrationsOnLocalDockerInfrastructure;

    [PublicAPI]
    public Target StartLocalDockerInfrastructure => DockerComposeTargets.StartLocalDockerInfrastructure;

    [PublicAPI]
    public Target StopLocalDockerInfrastructure => DockerComposeTargets.StopLocalDockerInfrastructure;

    [PublicAPI]
    public Target CleanLocalDockerInfrastructure => DockerComposeTargets.CleanLocalDockerInfrastructure;
        
    [PublicAPI]
    public Target DisplayLocalDockerInfrastructureLogs => DockerComposeTargets.DisplayLocalDockerInfrastructureLogs;
        
    [PublicAPI]
    public Target PrepareCertificates => CertsTargets.PrepareCertificates;

    [PublicAPI]
    public Target CleanCertificates => CertsTargets.CleanCertificates;

    [PublicAPI]
    public Target CreateElasticUsers => ElasticTargets.CreateElasticUsers;

    [PublicAPI]
    public Target CleanElasticUsers => ElasticTargets.CleanElasticUsers;
}