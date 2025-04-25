using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

public readonly struct CartPriced(DateTime pricedOn, Guid clientId, string currency, ImmutableArray<QuoteDto> quotes)
{
    public DateTime PricedOn { get; } = pricedOn;
    public Guid ClientId { get; } = clientId;
    public string Currency { get; } = currency;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
}