using System.Reflection;
using MyCompany.ECommerce.TechnicalStuff.Metadata;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Domain.DDD;
using Scrutor;

namespace MyCompany.ECommerce.DI;

public static class ConventionBasedRegistrations
{
    public static IServiceCollection AddStatelessComponentsFrom(this IServiceCollection services,
        params Assembly[] assemblies) =>
        services.Scan(selector => selector
            .FromAssemblies(assemblies)
            .AddClasses(filter => filter.WithAnyAttribute(
                    typeof(DaoAttribute),
                    typeof(DddRepositoryAttribute),
                    typeof(DddFactoryAttribute),
                    typeof(DddDomainServiceAttribute),
                    typeof(DddApplicationServiceAttribute),
                    typeof(ExternalSystemIntegrationAttribute)),
                false)
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

    private static IImplementationTypeFilter WithAnyAttribute(this IImplementationTypeFilter filter,
        params Type[] attributes) =>
        filter.Where(t => attributes.Any(a => t.HasAttribute(a)));

    private static bool HasAttribute(this Type type, Type attributeType) =>
        type.GetTypeInfo().IsDefined(attributeType, inherit: true);
}