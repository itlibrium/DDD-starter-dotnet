using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[Process(FullName, ApplyOnNamespace = true)]
public class WholesaleOrderingProcess
{
    public const string Name = "Wholesale ordering";
    public const string FullName = SaleProcess.FullName + "." + Name;
}