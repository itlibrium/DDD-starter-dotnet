using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales;

[Process(Name, ApplyOnNamespace = true)]
public static class SaleProcess
{
    public const string Name = "Sale";
}