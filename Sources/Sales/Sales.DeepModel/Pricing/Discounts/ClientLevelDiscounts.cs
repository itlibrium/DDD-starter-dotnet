using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts;

[DddDomainService]
public class ClientLevelDiscounts(PercentageDiscount baseDiscountValue, 
    IEnumerable<ProductDiscount> productDiscounts) : OfferModifier, QuoteModifier
{
    private readonly PercentageDiscount _baseDiscount = baseDiscountValue;

    private readonly ImmutableDictionary<ProductUnit, Discount> _productDiscounts = productDiscounts.ToImmutableDictionary(
            d => d.ProductUnit, d => d.Discount);

    public Offer ApplyOn(Offer offer) => offer.Apply((QuoteModifier) this);

    public Quote ApplyOn(Quote quote)
    {
        var productAmount = quote.ProductAmount;
        return _productDiscounts.TryGetValue(productAmount.ProductUnit, out var discount)
            ? quote.Apply(discount)
            : quote.Apply(_baseDiscount);
    }
}