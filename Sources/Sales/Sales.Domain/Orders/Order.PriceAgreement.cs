using System;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        private readonly struct PriceAgreement
        {
            public ImmutableArray<Quote> Quotes { get; }
            private readonly DateTime _expiresOn;

            public static PriceAgreement Non() => 
                new PriceAgreement(ImmutableArray<Quote>.Empty, DateTime.MinValue);
            public static PriceAgreement Temporary(ImmutableArray<Quote> quotes, DateTime expiresOn) => 
                new PriceAgreement(quotes, expiresOn);

            private PriceAgreement(ImmutableArray<Quote> quotes, DateTime expiresOn)
            {
                Quotes = quotes;
                _expiresOn = expiresOn;
            }

            public bool IsValidOn(DateTime date) => _expiresOn >= date;
        }
    }
}