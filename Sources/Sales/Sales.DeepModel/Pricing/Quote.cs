using System;
using System.Text.Json.Serialization;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddValueObject]
    public readonly struct Quote : IEquatable<Quote>
    {
        public ProductAmount ProductAmount { get; }
        public Money Price { get; }

        public static Quote For(ProductAmount productAmount, Money price) => new(productAmount, price);

        [JsonConstructor]
        public Quote(ProductAmount productAmount, Money price)
        {
            ProductAmount = productAmount;
            Price = price;
        }
        
        internal Quote Apply<TPriceModifier>(TPriceModifier priceModifier)
            where TPriceModifier : struct, PriceModifier => new(ProductAmount, priceModifier.ApplyOn(Price));

        internal Quote Apply(QuoteModifier quoteModifier) => quoteModifier.ApplyOn(this);

        public Quote ChangePrice(Money newPrice) => new(ProductAmount, newPrice);

        public static Quote operator +(Quote x, Quote y) => For(x.ProductAmount + y.ProductAmount, x.Price + y.Price);

        public bool Equals(Quote other) => (ProductAmount, Price).Equals((other.ProductAmount, other.Price));
        public override bool Equals(object? obj) => obj is Quote other && Equals(other);
        public override int GetHashCode() => (ProductAmount, Price).GetHashCode();

        public override string ToString() => $"{ProductAmount} - {Price}";
    }
}