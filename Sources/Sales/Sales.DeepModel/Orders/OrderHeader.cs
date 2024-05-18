using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using MyCompany.ECommerce.TechnicalStuff.Metadata;
using Newtonsoft.Json;

namespace MyCompany.ECommerce.Sales.Orders;

[DataStructure]
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