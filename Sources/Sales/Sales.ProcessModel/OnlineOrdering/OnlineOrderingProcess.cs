using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[Process(Name, ApplyOnNamespace = true)]
public class OnlineOrderingProcess
{
    public const string Name = "Online ordering";
}