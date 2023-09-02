using System.Reflection;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Sales;

public static class SalesProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(SalesProcessModelLayerInfo).Assembly;
}