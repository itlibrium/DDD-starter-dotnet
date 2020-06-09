using System;
using JetBrains.Annotations;
using MyCompany.Crm.Nuke.Certs;
using MyCompany.Crm.Nuke.DockerCompose;
using MyCompany.Crm.Nuke.DotNet;
using MyCompany.Crm.Nuke.Elastic;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;

namespace MyCompany.Crm.Nuke
{
    [CheckBuildProjectConfigurations]
    [UnsetVisualStudioEnvironmentVariables]
    public class Build : NukeBuild
    {
        public static int Main() => Execute<Build>(x => x.Compile);

        [Solution]
        public static Solution Solution { get; private set; }
        // [GitRepository] readonly GitRepository GitRepository;
        // [GitVersion] readonly GitVersion GitVersion;

        [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
        public static Configuration BuildConfiguration { get; private set; } = IsLocalBuild
            ? Configuration.Debug
            : Configuration.Release;

        [Parameter]
        public static string ExecutingUser { get; private set; } = "1000";

        [Parameter]
        public static Environment Environment
        {
            get
            {
                if (!_environment.Equals(Environment.Undefined))
                    return _environment;
                if (!AspNetCoreEnvironment.Equals(Environment.Undefined))
                    return AspNetCoreEnvironment;
                if (!DotNetEnvironment.Equals(Environment.Undefined))
                    return DotNetEnvironment;
                return Environment.Development;
            }
            private set
            {
                if (value.Equals(Environment.Undefined))
                    throw new ArgumentException($"{nameof(Environment)} can not be set to {Environment.Undefined}");
                _environment = value;
            }
        }

        private static Environment _environment = Environment.Undefined;

        [Parameter]
        public static Environment DotNetEnvironment { get; private set; } = Environment.Undefined;

        [Parameter]
        public static Environment AspNetCoreEnvironment { get; private set; } = Environment.Undefined;

        [PublicAPI]
        public Target PrepareCertificates => CertsTargets.PrepareCertificates;
        
        [PublicAPI]
        public Target CleanCertificates => CertsTargets.CleanCertificates;
        
        [PublicAPI]
        public Target StartDockerComposeInfrastructure => DockerComposeTargets.StartDockerComposeInfrastructure;
        
        [PublicAPI]
        public Target StopDockerComposeInfrastructure => DockerComposeTargets.StopDockerComposeInfrastructure;
        
        [PublicAPI]
        public Target CleanDockerComposeInfrastructure => DockerComposeTargets.CleanDockerComposeInfrastructure;
        
        [PublicAPI]
        public Target Clean => DotNetTargets.Clean;

        [PublicAPI]
        public Target Restore => DotNetTargets.Restore;

        [PublicAPI]
        public Target Compile => DotNetTargets.Compile;
        
        [PublicAPI]
        public Target CreateElasticUsers => ElasticTargets.CreateElasticUsers;
        
        [PublicAPI]
        public Target CleanElasticUsers => ElasticTargets.CleanElasticUsers;
    }
}