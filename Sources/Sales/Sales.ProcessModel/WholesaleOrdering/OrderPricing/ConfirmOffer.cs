using System;
using System.Collections.Immutable;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
{
    [ProcessStepContract]
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