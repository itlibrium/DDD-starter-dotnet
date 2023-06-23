using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[Process(FullName, ApplyOnNamespace = true)]
public class OnlineOrderingProcess
{
    public const string Name = "Online ordering";
    public const string FullName = SaleProcess.FullName + "." + Name;
}