using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing;

public class OfferCalculated(Guid orderId, ImmutableArray<QuoteDto> quotes)
{
    public Guid OrderId { get; } = orderId;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
}