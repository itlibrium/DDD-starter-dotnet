using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Fulfillment;

public readonly struct RequestOrderAcceptance : Command
{
    public Guid OrderId { get; }

    public RequestOrderAcceptance(Guid orderId) => OrderId = orderId;
}