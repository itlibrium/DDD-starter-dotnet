using System;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.OrderPlacement
{
    [ProcessStepContract]
    public class OrderPlaced : OrderEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public DateTime PlacedOn { get; }

        public OrderPlaced(Guid orderId, Guid clientId, DateTime placedOn)
        {
            OrderId = orderId;
            ClientId = clientId;
            PlacedOn = placedOn;
        }
    }
}