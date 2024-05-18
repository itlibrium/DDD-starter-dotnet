using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddEntity]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class OrderNote : CrudEntity
{
    [BindNever]
    public Guid OrderId { get; set; }

    [BindNever]
    public Guid AuthorId { get; set; }

    [BindNever]
    public DateTime AddedOn { get; set; }

    [BindRequired]
    public string Text { get; set; }
    //...
}