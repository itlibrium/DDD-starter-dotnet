using System;
using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
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