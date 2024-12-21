using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Pricing;

namespace MyCompany.ECommerce.Sales.Orders.PriceChanges;

public class FakePriceChangesPolicy : PriceChangesPolicy
{
    public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) => true;
}