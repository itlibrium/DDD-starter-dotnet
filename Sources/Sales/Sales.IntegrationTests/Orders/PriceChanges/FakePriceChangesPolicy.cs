using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    public class FakePriceChangesPolicy : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) => true;
    }
}