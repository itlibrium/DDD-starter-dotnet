using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    public class AllowAnyPriceChanges : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> actualQuotes, ImmutableArray<Quote> newQuotes) => true;
    }
}