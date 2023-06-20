using MyCompany.ECommerce.Sales.Fulfillment;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[Process(SaleProcess.Name, Name,
    ApplyOnNamespace = true,
    NextSubProcesses = new[] { FulfillmentProcess.Name })]
public class OnlineOrderingProcess
{
    public const string Name = "Online ordering";
}