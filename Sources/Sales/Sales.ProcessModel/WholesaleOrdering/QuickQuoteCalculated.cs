namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public class QuickQuoteCalculated(Guid clientId, QuoteDto quote)
{
    public Guid ClientId { get; } = clientId;
    public QuoteDto Quote { get; } = quote;
}