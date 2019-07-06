using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public class ProductLevelDiscounts : OfferModifier
    {
        private readonly ImmutableDictionary<(ProductId, AmountUnit), Discount> _discounts;

        public static ProductLevelDiscounts Of(IEnumerable<ProductDiscount> discounts) => 
            new ProductLevelDiscounts(discounts.ToImmutableDictionary(
                d => (d.ProductId, d.AmountUnit), d => d.Discount));

        private ProductLevelDiscounts(ImmutableDictionary<(ProductId, AmountUnit), Discount> discounts) => 
            _discounts = discounts;

        public Offer ApplyOn(Offer offer) => Offer.FromQuotes(offer.Quotes.Select(RecalculateQuote));

        private Quote RecalculateQuote(Quote quote)
        {
            var productAmount = quote.ProductAmount;
            return _discounts.TryGetValue((productAmount.ProductId, productAmount.Unit), out var discount)
                ? quote.Apply(discount)
                : quote;
        }
    }

    public static class ProductLevelDiscounts2
    {
        public static OfferModifier2 ProductLevelDiscounts(IEnumerable<ProductDiscount> discounts) =>
            ProductLevelDiscounts(discounts.ToImmutableDictionary(
                d => (d.ProductId, d.AmountUnit), 
                d => d.Discount));


        private static OfferModifier2 ProductLevelDiscounts(
            ImmutableDictionary<(ProductId, AmountUnit), Discount> discounts) =>
            offer => Offer.FromQuotes(offer.Quotes.Select(quote => RecalculateQuote(quote, discounts)));
        
        private static Quote RecalculateQuote(Quote quote, 
            ImmutableDictionary<(ProductId, AmountUnit), Discount> discounts)
        {
            var productAmount = quote.ProductAmount;
            return discounts.TryGetValue((productAmount.ProductId, productAmount.Unit), out var discount)
                ? quote.Apply(discount)
                : quote;
        }
    }
}