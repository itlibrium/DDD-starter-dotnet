using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyCompany.Crm
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureLogging(logging => logging
                .ClearProviders()
                .AddConsole())
            .ConfigureWebHostDefaults(webBuilder => webBuilder
                .UseStartup<Startup>())
            .UseDefaultServiceProvider(ConfigureServiceProvider);

        private static void ConfigureServiceProvider(HostBuilderContext context, ServiceProviderOptions options)
        {
            var isNotProduction = !context.HostingEnvironment.IsProduction();
            options.ValidateScopes = isNotProduction;
            options.ValidateOnBuild = isNotProduction;
        }
    }
}