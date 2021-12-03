using System;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Fulfillment
{
    public readonly struct RequestOrderAcceptance : Command
    {
        public Guid OrderId { get; }

        public RequestOrderAcceptance(Guid orderId) => OrderId = orderId;
    }
}