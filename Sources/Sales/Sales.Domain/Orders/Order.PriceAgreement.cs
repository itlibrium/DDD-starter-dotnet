using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Pricing;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        private readonly struct PriceAgreement
        {
            private readonly ImmutableArray<Quote> _quotes;
            private readonly DateTime _expiresOn;

            public static PriceAgreement Non() => 
                new PriceAgreement(ImmutableArray<Quote>.Empty, DateTime.MinValue);
            public static PriceAgreement Temporary(IEnumerable<Quote> quotes, DateTime expiresOn) => 
                new PriceAgreement(quotes.ToImmutableArray(), expiresOn);

            private PriceAgreement(ImmutableArray<Quote> quotes, DateTime expiresOn)
            {
                _quotes = quotes;
                _expiresOn = expiresOn;
            }

            public bool IsValidOn(DateTime date) => _expiresOn >= date;
        }
    }
}