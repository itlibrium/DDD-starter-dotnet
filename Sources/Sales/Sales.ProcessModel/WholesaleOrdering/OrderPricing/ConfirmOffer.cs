using System;
using System.Collections.Immutable;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
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