using System.Reflection;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology;

[assembly: Layer("Process Model")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.ProductsDelivery;

public class ProductsDeliveryProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryProcessModelLayerInfo).Assembly;
}