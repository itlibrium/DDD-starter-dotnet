using System;

namespace MyCompany.Crm.Sales.Wholesale.CreateOrder
{
    public readonly struct OrderCreated
    {
        public Guid OrderId { get; }
        
        public Guid ClientId { get; }

        public OrderCreated(Guid orderId, Guid clientId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}