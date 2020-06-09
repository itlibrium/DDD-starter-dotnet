using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    public interface PriceChangesPolicy
    {
        bool CanChangePrices(ImmutableArray<Quote> actualQuotes, ImmutableArray<Quote> newQuotes);
    }
}