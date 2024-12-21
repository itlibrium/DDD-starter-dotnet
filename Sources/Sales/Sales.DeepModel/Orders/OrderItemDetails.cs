using JetBrains.Annotations;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddValueObject]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class OrderItemDetails
{
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
    public string AmountUnit { get; set; }
    public decimal Price { get; set; }
}