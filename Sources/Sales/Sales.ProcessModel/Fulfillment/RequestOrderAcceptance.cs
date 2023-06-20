using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.Fulfillment;

[ProcessStepContract]
public readonly struct RequestOrderAcceptance : Command
{
    public Guid OrderId { get; }

    public RequestOrderAcceptance(Guid orderId) => OrderId = orderId;
}