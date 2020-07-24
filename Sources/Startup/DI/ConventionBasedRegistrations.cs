using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.DI
{
    public static class ConventionBasedRegistrations
    {
        public static IServiceCollection AddStatelessComponents(this IServiceCollection services,
            params Assembly[] assemblies) =>
            services.Scan(selector => selector
                .FromAssemblies(assemblies)
                .AddClasses(filter => filter.WithAttribute<StatelessAttribute>(), false)
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
    }
}