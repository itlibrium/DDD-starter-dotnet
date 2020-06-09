using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.Wholesale.ConfirmOffer
{
    public readonly struct ConfirmOfferCommand
    {
        public Guid OrderId { get; }
        public string CurrencyCode { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public ConfirmOfferCommand(Guid orderId, string currencyCode, ImmutableArray<QuoteDto> quotes)
        {
            OrderId = orderId;
            CurrencyCode = currencyCode;
            Quotes = quotes;
        }
    }
}