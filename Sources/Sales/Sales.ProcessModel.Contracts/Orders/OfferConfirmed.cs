using System;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Wholesale;

namespace MyCompany.Crm.Sales.Orders
{
    public class OfferConfirmed : OrderEvent
    {
        public Guid OrderId { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public OfferConfirmed(Guid orderId, ImmutableArray<QuoteDto> quotes)
        {
            OrderId = orderId;
            Quotes = quotes;
        }
    }
}