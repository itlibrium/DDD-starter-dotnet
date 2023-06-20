using System.Reflection;
using P3Model.Annotations.Technology;

[assembly: Layer("Process Model")]

namespace MyCompany.ECommerce.ProductsDelivery;

public class ProductsDeliveryProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(ProductsDeliveryProcessModelLayerInfo).Assembly;
}