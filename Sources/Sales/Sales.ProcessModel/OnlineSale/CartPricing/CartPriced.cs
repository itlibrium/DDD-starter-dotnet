using System;
using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.OnlineSale.CartPricing
{
    public readonly struct CartPriced
    {
        public DateTime PricedOn { get; }
        public Guid ClientId { get; }
        public string Currency { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public CartPriced(DateTime pricedOn, Guid clientId, string currency, ImmutableArray<QuoteDto> quotes)
        {
            PricedOn = pricedOn;
            ClientId = clientId;
            Currency = currency;
            Quotes = quotes;
        }
    }
}