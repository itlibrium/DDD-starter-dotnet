using System.Reflection;
using System.Runtime.CompilerServices;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology;

[assembly: InternalsVisibleTo("MyCompany.Crm.Startup")]
[assembly: InternalsVisibleTo("MyCompany.Crm.Sales.IntegrationTests")]
[assembly: Layer("Deep Model")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Sales;

public static class SalesDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(SalesDeepModelLayerInfo).Assembly;
}