using System.Collections.Generic;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public class ClientLevelDiscounts : OfferModifier, QuoteModifier
    {
        private readonly PercentageDiscount _baseDiscount;

        private readonly ImmutableDictionary<ProductUnit, Discount> _productDiscounts;

        public ClientLevelDiscounts(PercentageDiscount baseDiscountValue, IEnumerable<ProductDiscount> productDiscounts)
        {
            _baseDiscount = baseDiscountValue;
            _productDiscounts = productDiscounts.ToImmutableDictionary(
                d => d.ProductUnit, d => d.Discount);
        }

        public Offer ApplyOn(Offer offer) => offer.Apply((QuoteModifier) this);

        public Quote ApplyOn(Quote quote)
        {
            var productAmount = quote.ProductAmount;
            return _productDiscounts.TryGetValue(productAmount.ProductUnit, out var discount)
                ? quote.Apply(discount)
                : quote.Apply(_baseDiscount);
        }
    }
}