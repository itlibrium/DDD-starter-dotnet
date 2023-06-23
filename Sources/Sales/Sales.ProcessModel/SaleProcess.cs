using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales;

[Process(FullName, ApplyOnNamespace = true)]
public static class SaleProcess
{
    public const string FullName = "Sale";
}