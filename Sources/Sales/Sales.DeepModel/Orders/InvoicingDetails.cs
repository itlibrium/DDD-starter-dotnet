using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddValueObject]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class InvoicingDetails
{
    [BindRequired] public string TaxId { get; set; }
    [BindRequired] public string Name { get; set; }
    //...
}