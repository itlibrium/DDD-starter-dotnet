using System;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        private readonly struct PriceAgreement
        {
            private readonly ImmutableArray<Quote> _quotes;
            public DateTime? ExpiresOn { get; }

            public static PriceAgreement Non() =>
                new PriceAgreement(ImmutableArray<Quote>.Empty, null);

            public static PriceAgreement Temporary(ImmutableArray<Quote> quotes, DateTime expiresOn) =>
                new PriceAgreement(quotes, expiresOn);

            private PriceAgreement(ImmutableArray<Quote> quotes, DateTime? expiresOn)
            {
                _quotes = quotes;
                ExpiresOn = expiresOn;
            }

            public bool CanChangePrices(ImmutableArray<Quote> newQuotes,
                DateTime now,
                PriceChangesPolicy priceChangesPolicy) =>
                !IsValidOn(now) || priceChangesPolicy.CanChangePrices(_quotes, newQuotes);
            
            public bool IsValidOn(DateTime date) => ExpiresOn is null || ExpiresOn >= date;

            public Money? GetPrice(ProductAmount productAmount)
            {
                var quote = _quotes.SingleOrDefault(q => q.ProductAmount.Equals(productAmount));
                return quote.Price.IsEmpty ? (Money?) null : quote.Price;
            }
        }
    }
}