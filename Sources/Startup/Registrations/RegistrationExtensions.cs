using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Registrations
{
    internal static class RegistrationExtensions
    {
        public static void AddStatelessComponents(this IServiceCollection services, params Assembly[] assemblies)
            => services.Scan(selector => selector
                .FromAssemblies(assemblies)
                .AddClasses(filter => filter.WithAttribute<StatelessAttribute>(), false)
                .AsSelf()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}