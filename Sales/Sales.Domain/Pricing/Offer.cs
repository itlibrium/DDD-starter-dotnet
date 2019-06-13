using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.ExchangeRates;
using MyCompany.Crm.Sales.Pricing.PriceLists;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing
{
    public readonly struct Offer : IEquatable<Offer>
    {
        public Currency Currency { get; }
        public ImmutableArray<Quote> Quotes { get; }
        public Money TotalPrice => 
            Quotes.Aggregate(Money.Zero(Currency), (sum, quote) => sum + quote.Price);
        public ImmutableArray<ProductAmount> ProductAmounts => 
            Quotes.Select(quote => quote.ProductAmount).ToImmutableArray();

        public static Offer FromQuotes(IEnumerable<Quote> quotes) => new Offer(quotes);
        public static Offer WithBasePrices(ImmutableArray<ProductAmount> productAmounts, BasePrices basePrices) => 
            FromQuotes(productAmounts.Select(productAmount => 
                Quote.For(productAmount, basePrices.GetFor(productAmount))));

        private Offer(IEnumerable<Quote> quotes)
        {
            Quotes = quotes.ToImmutableArray();
            if(Quotes.Length == 0) throw new DomainException();
            
            Currency = Quotes[0].Price.Currency;
            foreach (var quote in Quotes)
                if (quote.Price.Currency != Currency) throw new DomainException();
        }

        public Offer ChangeCurrency(ExchangeRate exchangeRate) => exchangeRate.To == Currency
            ? this
            : new Offer(Quotes.Select(quote => quote.ChangeCurrency(exchangeRate)));

        public bool Compare(Offer other, Percentage accuracy) => TotalPrice / other.TotalPrice > accuracy;
        
        public bool Equals(Offer other) => Quotes.Equals(other.Quotes);
        public override bool Equals(object obj) => obj is Offer other && Equals(other);
        public override int GetHashCode() => Quotes.GetHashCode();

        public override string ToString() => $"Offer with total price: {TotalPrice.ToString()}";
    }
}