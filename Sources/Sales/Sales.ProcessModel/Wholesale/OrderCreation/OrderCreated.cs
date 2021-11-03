using System;

namespace MyCompany.Crm.Sales.Wholesale.OrderCreation
{
    public class OrderCreated : OrderEvent
    {
    public Guid OrderId { get; }
    public Guid ClientId { get; }
    public string SalesChannel { get; }

    public OrderCreated(Guid orderId, Guid clientId, string salesChannel)
    {
        OrderId = orderId;
        ClientId = clientId;
        SalesChannel = salesChannel;
    }
    }
}