namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation;

public class OrderCreated(Guid orderId, Guid clientId, string salesChannel) : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public Guid ClientId { get; } = clientId;
    public string SalesChannel { get; } = salesChannel;
}