using System;

namespace MyCompany.Crm.Sales.Wholesale.PlaceOrder
{
    public readonly struct PlaceOrderCommand
    {
        public Guid OrderId { get; }

        public PlaceOrderCommand(Guid orderId) => OrderId = orderId;
    }
}