using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.ProductsDelivery;

[Process(Name, ApplyOnNamespace = true)]
public static class ProductsDeliveryProcess
{
    public const string Name = "Products delivery";
}