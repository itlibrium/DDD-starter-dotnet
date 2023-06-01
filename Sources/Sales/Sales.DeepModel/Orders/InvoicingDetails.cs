using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.Orders
{
    [DataStructure]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class InvoicingDetails
    {
        [BindRequired] public string TaxId { get; set; }
        [BindRequired] public string Name { get; set; }
        //...
    }
}