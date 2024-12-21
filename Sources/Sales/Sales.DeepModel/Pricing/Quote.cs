using System.Text.Json.Serialization;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddValueObject]
[method: JsonConstructor]
public readonly struct Quote(ProductAmount productAmount, Money price) : IEquatable<Quote>
{
    public ProductAmount ProductAmount { get; } = productAmount;
    public Money Price { get; } = price;

    public static Quote For(ProductAmount productAmount, Money price) => new(productAmount, price);

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