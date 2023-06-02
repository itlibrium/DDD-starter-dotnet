using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[Process(Name, Parent = SaleProcess.Name)]
public class WholesaleOrderingProcess
{
    public const string Name = "Wholesale ordering";
}