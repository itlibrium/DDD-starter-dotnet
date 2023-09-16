using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[Process(Name, ApplyOnNamespace = true)]
public class OnlineOrderingProcess
{
    public const string Name = "Online ordering";
}