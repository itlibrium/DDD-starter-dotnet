using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.Sales;

[UsedImplicitly]
public static class SalesRestApiLayerInfo
{
    public static Assembly Assembly => typeof(SalesRestApiLayerInfo).Assembly;
}