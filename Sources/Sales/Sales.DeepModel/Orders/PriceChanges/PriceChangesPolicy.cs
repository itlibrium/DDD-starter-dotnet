using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    [DddPolicy]
    public interface PriceChangesPolicy
    {
        bool CanChangePrices(ImmutableArray<Quote> actualQuotes, ImmutableArray<Quote> newQuotes);
    }
}