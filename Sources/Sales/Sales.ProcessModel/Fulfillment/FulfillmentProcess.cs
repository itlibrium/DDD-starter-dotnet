using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.Fulfillment;

[Process(Name,  Parent = SaleProcess.Name)]
public class FulfillmentProcess
{
    public const string Name = "Fulfillment";
}