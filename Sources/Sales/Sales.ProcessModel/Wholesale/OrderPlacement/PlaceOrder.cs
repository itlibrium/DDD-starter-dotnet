using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.OrderPlacement
{
    public readonly struct PlaceOrder : Command
    {
        public Guid OrderId { get; }

        public PlaceOrder(Guid orderId) => OrderId = orderId;
    }
}