using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.ProductsDelivery;

[UsedImplicitly]
public class ProductsDeliveryDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryDeepModelLayerInfo).Assembly;
}