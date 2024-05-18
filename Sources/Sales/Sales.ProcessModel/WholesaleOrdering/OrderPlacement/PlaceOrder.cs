using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement
{
    public readonly struct PlaceOrder : Command
    {
        public Guid OrderId { get; }

        public PlaceOrder(Guid orderId) => OrderId = orderId;
    }
}