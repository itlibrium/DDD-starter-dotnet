using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[Process(Name, ApplyOnNamespace = true)]
public static class WholesaleOrderingProcess
{
    public const string Name = "Wholesale ordering";
}