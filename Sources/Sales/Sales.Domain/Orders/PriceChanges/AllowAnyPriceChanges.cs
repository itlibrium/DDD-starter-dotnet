using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    [Stateless]
    [DddPolicy]
    public class AllowAnyPriceChanges : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> actualQuotes, ImmutableArray<Quote> newQuotes) => true;
    }
}