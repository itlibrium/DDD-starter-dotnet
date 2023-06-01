using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Orders.PriceChanges
{
    [DddDomainService]
    public class AllowPriceChangesIfTotalPriceIsLower : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) =>
            GetTotalPrice(newQuotes) < GetTotalPrice(oldQuotes.Where(q => newQuotes.Contains(q)));

        private static Money GetTotalPrice(IEnumerable<Quote> quotes) => quotes
            .Select(quote => quote.Price)
            .Aggregate((totalPrice, price) => totalPrice + price);
    }
}