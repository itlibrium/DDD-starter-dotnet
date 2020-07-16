using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.Wholesale.ConfirmOffer
{
    public readonly struct OfferConfirmed
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