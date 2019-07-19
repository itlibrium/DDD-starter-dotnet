using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.OnlineSales.PlaceOrder
{
    public readonly struct PlaceOrderCommand
    {
        public Guid ClientId { get; }
        public string Currency { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public PlaceOrderCommand(Guid clientId, string currency, ImmutableArray<QuoteDto> quotes)
        {
            ClientId = clientId;
            Currency = currency;
            Quotes = quotes;
        }
    }
}