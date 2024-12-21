using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing;

public class OfferConfirmed(Guid orderId, ImmutableArray<QuoteDto> quotes) : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
}