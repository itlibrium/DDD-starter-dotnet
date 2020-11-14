using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyCompany.Crm.Sales.Orders
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class InvoicingDetails
    {
        [BindRequired] public string TaxId { get; set; }
        [BindRequired] public string Name { get; set; }
        //...
    }
}