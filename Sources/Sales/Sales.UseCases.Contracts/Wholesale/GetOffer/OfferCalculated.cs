using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.Wholesale.GetOffer
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