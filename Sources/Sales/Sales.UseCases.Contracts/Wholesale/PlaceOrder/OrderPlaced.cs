using System;

namespace MyCompany.Crm.Sales.Wholesale.PlaceOrder
{
    public class OrderPlaced : OrderEvent
    {
        public Guid OrderId { get; }

        public OrderPlaced(Guid orderId) => OrderId = orderId;
    }
}