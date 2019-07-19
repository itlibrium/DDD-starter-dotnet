using System;

namespace MyCompany.Crm.Sales.Wholesale.PlaceOrder
{
    public readonly struct OrderPlaced
    {
        public Guid OrderId { get; }

        public OrderPlaced(Guid orderId) => OrderId = orderId;
    }
}