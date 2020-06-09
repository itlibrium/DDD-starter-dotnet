using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechnicalStuff.Crud;

namespace MyCompany.Crm.Sales.Orders
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderNote : CrudEntity
    {
        [BindNever] public Guid OrderId { get; set; }
        [BindNever] public Guid AuthorId { get; set; }
        [BindNever] public DateTime AddedOn { get; set; }
        [BindRequired] public string Text { get; set; }
        //...
    }
}