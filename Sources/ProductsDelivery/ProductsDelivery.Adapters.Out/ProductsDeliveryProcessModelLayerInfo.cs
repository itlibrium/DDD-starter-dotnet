using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.ProductsDelivery;

[UsedImplicitly]
public class ProductsDeliveryProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryProcessModelLayerInfo).Assembly;
}