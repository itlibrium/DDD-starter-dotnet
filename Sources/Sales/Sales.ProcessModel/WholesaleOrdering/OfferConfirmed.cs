using System.Collections.Immutable;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public class OfferConfirmed(Guid orderId, ImmutableArray<QuoteDto> quotes) : OrderEvent
{
    public Guid OrderId { get; } = orderId;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
}