using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts;

[DddDomainService]
public class ProductLevelDiscounts : OfferModifier, QuoteModifier
{
    private readonly ImmutableDictionary<ProductUnit, Discount> _discounts;

    public static ProductLevelDiscounts Of(IEnumerable<ProductDiscount> discounts) => 
        new(discounts.ToImmutableDictionary(
            d => d.ProductUnit, 
            d => d.Discount));

    private ProductLevelDiscounts(ImmutableDictionary<ProductUnit, Discount> discounts) => 
        _discounts = discounts;

    public Offer ApplyOn(Offer offer) => offer.Apply((QuoteModifier) this);

    public Quote ApplyOn(Quote quote)
    {
        var productAmount = quote.ProductAmount;
        return _discounts.TryGetValue(productAmount.ProductUnit, out var discount)
            ? quote.Apply(discount)
            : quote;
    }
}

public static class ProductLevelDiscounts2
{
    public static OfferModifier2 ProductLevelDiscounts(IEnumerable<ProductDiscount> discounts) =>
        ProductLevelDiscounts(discounts.ToImmutableDictionary(
            d => d.ProductUnit, 
            d => d.Discount));

    private static OfferModifier2 ProductLevelDiscounts(ImmutableDictionary<ProductUnit, Discount> discounts) =>
        offer => Offer.FromQuotes(offer.Currency, offer.Quotes.Select(quote => RecalculateQuote(quote, discounts)));
        
    private static Quote RecalculateQuote(Quote quote, ImmutableDictionary<ProductUnit, Discount> discounts) =>
        discounts.TryGetValue(quote.ProductAmount.ProductUnit, out var discount)
            ? quote.Apply(discount)
            : quote;
}