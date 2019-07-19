using System.Collections.Generic;
using System.Collections.Immutable;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.PriceLists
{
    public readonly struct BasePrices
    {
        private readonly ImmutableDictionary<(ProductId ProductId, AmountUnit AmountUnit), Money> _prices;

        public static BasePrices Of(IEnumerable<BasePrice> prices) => new BasePrices(prices);

        private BasePrices(IEnumerable<BasePrice> prices) => 
            _prices = prices.ToImmutableDictionary(
                p => (p.ProductId, p.AmountUnit), p => p.Price);

        public Money GetFor(ProductAmount productAmount) =>
            _prices.TryGetValue((productAmount.ProductId, productAmount.Unit), out var price) 
                ? price * productAmount.Value 
                : throw new DomainException();
    }
}