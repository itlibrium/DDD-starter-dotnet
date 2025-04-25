using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.PriceLists;

[DddValueObject]
public readonly struct BasePrices
{
    private readonly ImmutableDictionary<ProductUnit, Money> _prices;

    public static BasePrices Of(IEnumerable<BasePrice> prices) => new(prices);

    private BasePrices(IEnumerable<BasePrice> prices) => 
        _prices = prices.ToImmutableDictionary(
            p => p.ProductUnit, 
            p => p.Price);

    public Money GetFor(ProductAmount productAmount) =>
        _prices.TryGetValue(productAmount.ProductUnit, out var price) 
            ? price * productAmount.Amount.Value
            : throw new DomainError();
}