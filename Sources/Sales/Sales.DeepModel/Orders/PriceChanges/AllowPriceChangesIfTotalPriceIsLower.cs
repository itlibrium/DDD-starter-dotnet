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
        public bool CanChangePrices(ImmutableArray<Quote> actualQuotes, ImmutableArray<Quote> newQuotes) =>
            GetTotalPrice(newQuotes) < GetTotalPrice(actualQuotes);

        private static Money GetTotalPrice(ImmutableArray<Quote> quotes) => quotes
            .Select(quote => quote.Price)
            .Aggregate((totalPrice, price) => totalPrice + price);
    }
}