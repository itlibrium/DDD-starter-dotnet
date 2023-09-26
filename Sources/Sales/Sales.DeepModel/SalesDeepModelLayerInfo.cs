using System.Reflection;
using System.Runtime.CompilerServices;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Monolith.Startup")]
[assembly: InternalsVisibleTo("MyCompany.ECommerce.Sales.IntegrationTests")]
[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Sales;

public static class SalesDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(SalesDeepModelLayerInfo).Assembly;
}