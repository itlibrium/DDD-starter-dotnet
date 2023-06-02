using System;
using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
{
    public class OfferCalculated
    {
        public Guid OrderId { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public OfferCalculated(Guid orderId, ImmutableArray<QuoteDto> quotes)
        {
            OrderId = orderId;
            Quotes = quotes;
        }
    }
}