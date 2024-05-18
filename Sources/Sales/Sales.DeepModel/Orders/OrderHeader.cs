using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using Newtonsoft.Json;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddEntity]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class OrderHeader : CrudEntity
{
    [BindRequired]
    public Guid ClientId { get; set; }

    public InvoicingDetails InvoicingDetails { get; set; }

    [BindNever]
    [JsonIgnore]
    public List<OrderNote> Notes { get; set; }
        
    //...
}