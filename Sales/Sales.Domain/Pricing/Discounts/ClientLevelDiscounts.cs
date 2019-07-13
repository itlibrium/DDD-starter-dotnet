using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public class ClientLevelDiscounts : OfferModifier
    {
        private readonly PercentageDiscount _baseDiscount;

        private readonly ImmutableDictionary<(ProductId, AmountUnit), Discount> _productDiscounts;

        public ClientLevelDiscounts(PercentageDiscount baseDiscountValue, IEnumerable<ProductDiscount> productDiscounts)
        {
            _baseDiscount = baseDiscountValue;
            _productDiscounts = productDiscounts.ToImmutableDictionary(
                d => (d.ProductId, d.AmountUnit), d => d.Discount);
        }

        public Offer ApplyOn(Offer offer) => Offer.FromQuotes(offer.Quotes.Select(RecalculateQuote));

        internal Quote RecalculateQuote(Quote quote)
        {
            var productAmount = quote.ProductAmount;
            return _productDiscounts.TryGetValue((productAmount.ProductId, productAmount.Unit), out var discount)
                ? quote.Apply(discount)
                : quote.Apply(_baseDiscount);
        }
    }
}