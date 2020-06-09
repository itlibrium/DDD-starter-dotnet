using Microsoft.Extensions.Configuration;
using MyCompany.Crm.Nuke.Elastic;
using static MyCompany.Crm.Nuke.Paths;

namespace MyCompany.Crm.Nuke
{
    public static class Settings
    {
        public static ElasticSettings Elastic { get; }

        static Settings()
        {
            Elastic = GetParametersFromConfigurationRoot();
        }

        private static ElasticSettings GetParametersFromConfigurationRoot()
        {
            var configurationRoot = GetConfigurationRoot(Build.Environment);
            return configurationRoot.GetSection(ElasticSettings.Key).Get<ElasticSettings>();
        }

        private static IConfigurationRoot GetConfigurationRoot(Environment environment)
        {
            const string secretsId = "MyCompanyCrm";
            const string environmentVariablesPrefix = "MYCOMPANY_CRM_";
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(BuildDirectory / "settings.json", optional: true, reloadOnChange: false)
                .AddJsonFile(BuildDirectory / $"settings.{environment.ValueToLower()}.json", true, false);
            if (environment.Equals(Environment.Development))
                configurationBuilder.AddUserSecrets(secretsId);
            configurationBuilder.AddEnvironmentVariables(environmentVariablesPrefix);
            return configurationBuilder.Build();
        }
    }
}