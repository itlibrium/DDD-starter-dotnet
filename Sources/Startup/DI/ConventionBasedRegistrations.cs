using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using Scrutor;

namespace MyCompany.Crm.DI
{
    public static class ConventionBasedRegistrations
    {
        public static IServiceCollection AddStatelessComponentsFrom(this IServiceCollection services,
            params Assembly[] assemblies) =>
            services.Scan(selector => selector
                .FromAssemblies(assemblies)
                .AddClasses(filter => filter.WithAnyAttribute(
                        typeof(ExternalServiceAttribute),
                        typeof(DaoAttribute),
                        typeof(DddRepositoryAttribute),
                        typeof(DddFactoryAttribute),
                        typeof(DddDomainServiceAttribute),
                        typeof(DddAppServiceAttribute)),
                    false)
                .AsSelfWithInterfaces()
                .WithScopedLifetime());

        private static IImplementationTypeFilter WithAnyAttribute(this IImplementationTypeFilter filter,
            params Type[] attributes) =>
            filter.Where(t => attributes.Any(a => t.HasAttribute(a)));

        private static bool HasAttribute(this Type type, Type attributeType) =>
            type.GetTypeInfo().IsDefined(attributeType, inherit: true);
    }
}