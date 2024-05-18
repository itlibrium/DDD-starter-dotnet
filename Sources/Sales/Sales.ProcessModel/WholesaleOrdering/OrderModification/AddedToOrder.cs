namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderModification;

public class AddedToOrder(Guid orderId, Guid productId, int amount, string unitCode)
    : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid ProductId { get; } = productId;
    public int Amount { get; } = amount;
    public string UnitCode { get; } = unitCode;
}