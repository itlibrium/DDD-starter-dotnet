using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.OnlineSales.PlaceOrder
{
    public readonly struct PlaceOrderCommand
    {
        public Guid ClientId { get; }
        public string CurrencyCode { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public PlaceOrderCommand(Guid clientId, string currencyCode, ImmutableArray<QuoteDto> quotes)
        {
            ClientId = clientId;
            CurrencyCode = currencyCode;
            Quotes = quotes;
        }
    }
}