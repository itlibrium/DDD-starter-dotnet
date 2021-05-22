using System;
using System.Collections.Immutable;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.OrderPricing
{
    public readonly struct ConfirmOffer : Command
    {
        public Guid OrderId { get; }
        public string CurrencyCode { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }

        public ConfirmOffer(Guid orderId, string currencyCode, ImmutableArray<QuoteDto> quotes)
        {
            OrderId = orderId;
            CurrencyCode = currencyCode;
            Quotes = quotes;
        }
    }
}