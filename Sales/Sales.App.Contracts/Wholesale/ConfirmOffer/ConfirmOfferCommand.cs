using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.Wholesale.ConfirmOffer
{
    public readonly struct ConfirmOfferCommand
    {
        public Guid OrderId { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public ConfirmOfferCommand(Guid orderId, ImmutableArray<QuoteDto> quotes)
        {
            OrderId = orderId;
            Quotes = quotes;
        }
    }
}