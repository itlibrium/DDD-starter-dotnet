using System.Collections.Immutable;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public readonly struct ConfirmOffer(Guid orderId, string currencyCode, ImmutableArray<QuoteDto> quotes)
    : Command
{
    public Guid OrderId { get; } = orderId;
    public string CurrencyCode { get; } = currencyCode;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
}