namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public class OrderPlaced(Guid orderId, Guid clientId, DateTime placedOn) : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid ClientId { get; } = clientId;
    public DateTime PlacedOn { get; } = placedOn;
}