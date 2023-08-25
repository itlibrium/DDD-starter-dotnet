using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement
{
    [ProcessStepContract]
    public readonly struct PlaceOrder : Command
    {
        public Guid OrderId { get; }

        public PlaceOrder(Guid orderId) => OrderId = orderId;
    }
}