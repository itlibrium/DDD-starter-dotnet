using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Fulfillment
{
    public readonly struct RequestOrderAcceptance : Command
    {
        public Guid OrderId { get; }

        public RequestOrderAcceptance(Guid orderId) => OrderId = orderId;
    }
}