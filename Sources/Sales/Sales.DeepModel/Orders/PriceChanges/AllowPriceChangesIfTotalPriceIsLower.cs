using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders.PriceChanges
{
    [DddPolicy]
    public class AllowPriceChangesIfTotalPriceIsLower : PriceChangesPolicy
    {
        public bool CanChangePrices(ImmutableArray<Quote> oldQuotes, ImmutableArray<Quote> newQuotes) =>
            GetTotalPrice(newQuotes) < GetTotalPrice(oldQuotes.Where(q => newQuotes.Contains(q)));

        private static Money GetTotalPrice(IEnumerable<Quote> quotes) => quotes
            .Select(quote => quote.Price)
            .Aggregate((totalPrice, price) => totalPrice + price);
    }
}