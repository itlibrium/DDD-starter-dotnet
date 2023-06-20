using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.ProductsDelivery;

[Process(FullName, ApplyOnNamespace = true)]
public static class ProductsDeliveryProcess
{
    public const string Name = "Products delivery";
    public const string FullName = "Sale" + "." + Name;
}