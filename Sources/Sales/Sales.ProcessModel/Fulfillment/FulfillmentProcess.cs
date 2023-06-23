using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.Fulfillment;

[Process(FullName, ApplyOnNamespace = true)]
public static class FulfillmentProcess
{
    public const string Name = "Fulfillment";
    public const string FullName = SaleProcess.FullName + "." + "Fulfillment";
}