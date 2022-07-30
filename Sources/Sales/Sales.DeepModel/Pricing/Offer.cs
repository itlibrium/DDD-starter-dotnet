using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing.PriceLists;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddValueObject]
    public readonly struct Offer : IEquatable<Offer>
    {
        private readonly ImmutableDictionary<ProductUnit, Quote> _items;
        
        public Currency Currency { get; }

        public int Count => _items.Count;
        
        public Money TotalPrice => Quotes.Aggregate(Money.Zero(Currency), (sum, current) => sum + current.Price);
        
        public ImmutableArray<Quote> Quotes => _items.Values.ToImmutableArray();
        
        public ImmutableArray<ProductAmount> ProductAmounts => _items.Values
            .Select(quote => quote.ProductAmount)
            .ToImmutableArray();
        
        public static Offer FromQuotes(Currency currency, params Quote[] quotes) => new(currency, quotes);
        public static Offer FromQuotes(Currency currency, IEnumerable<Quote> quotes) => new(currency, quotes);

        internal static Offer WithBasePrices(ImmutableArray<ProductAmount> productAmounts, BasePrices basePrices) => 
            FromQuotes(Currency.PLN, productAmounts.Select(productAmount => 
                Quote.For(productAmount, basePrices.GetFor(productAmount))));

        private Offer(Currency currency, IEnumerable<Quote> quotes)
        {
            var items = quotes
                .GroupBy(quote => quote.ProductAmount.ProductUnit)
                .Select(grouping => grouping
                    .Aggregate((sum, current) => sum + current))
                .ToImmutableDictionary(quote => quote.ProductAmount.ProductUnit);
            if (items.Count == 0) throw new DomainError();
            if (items.Values.Any(quote => quote.Price.Currency != currency)) throw new DomainError();
            _items = items;
            Currency = currency;
        }

        internal Offer Apply(OfferModifier offerModifier) => offerModifier.ApplyOn(this);

        internal Offer Apply(QuoteModifier quoteModifier) =>
            FromQuotes(Currency, Quotes.Select(quote => quote.Apply(quoteModifier)));

        internal Offer Apply<TPriceModifier>(TPriceModifier priceModifier)
            where TPriceModifier : struct, PriceModifier
            => FromQuotes(Currency, Quotes.Select(quote => quote.Apply(priceModifier)));

        public bool Compare(Offer other, Percentage accuracy) => TotalPrice / other.TotalPrice > accuracy;
        
        // TODO: real Equals and GetHashCode
        public bool Equals(Offer other) => Quotes.Equals(other.Quotes);
        public override bool Equals(object obj) => obj is Offer other && Equals(other);
        public override int GetHashCode() => Quotes.GetHashCode();

        public override string ToString() => $"Offer with total price: {TotalPrice.ToString()}";
    }
}