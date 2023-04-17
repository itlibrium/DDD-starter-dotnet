using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    [DddDomainService]
    public class AllowAnyPriceChanges : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) => true;
    }
}