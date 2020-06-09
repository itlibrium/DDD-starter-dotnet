using System;
using System.Collections.Generic;
using System.Linq;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        public OrderId Id { get; }

        private readonly Dictionary<ProductUnit, Amount> _items = new Dictionary<ProductUnit, Amount>();

        private PriceAgreement _priceAgreement;
        private bool _isPlaced;

        public IEnumerable<ProductAmount> ProductAmounts =>
            _items.Select(pair => ProductAmount.Of(pair.Key.ProductId, pair.Value));

        public static Order New() => new Order(OrderId.New());

        public static Order FromOffer(Offer offer, DateTime priceAgreementExpiresOn)
        {
            var order = New();
            order.Add(offer.ProductAmounts);
            order.ConfirmPrices(offer, priceAgreementExpiresOn);
            order.Place(priceAgreementExpiresOn);
            return order;
        }

        private Order(OrderId id) => Id = id;

        public void Add(ProductAmount productAmount)
        {
            if (_isPlaced) throw new DomainException();
            AddOrUpdateItem(productAmount);
            _priceAgreement = PriceAgreement.Non();
        }

        private void Add(IEnumerable<ProductAmount> productAmounts)
        {
            if (_isPlaced) throw new DomainException();
            foreach (var productAmount in productAmounts)
                AddOrUpdateItem(productAmount);
            _priceAgreement = PriceAgreement.Non();
        }

        private void AddOrUpdateItem(ProductAmount productAmount)
        {
            var productUnit = productAmount.ProductUnit;
            if (_items.TryGetValue(productUnit, out var currentAmount))
                _items[productUnit] = currentAmount + productAmount.Amount;
            else
                _items.Add(productUnit, productAmount.Amount);
        }

        public void ConfirmPrices(Offer offer, DateTime priceAgreementExpiresOn, DateTime now, 
            PriceChangesPolicy priceChangesPolicy)
        {
            if (_isPlaced) throw new DomainException();
            if (!HasSameProductAmountsAs(offer))
                throw new DomainException();
            if (_priceAgreement.CanChangePrices(offer.Quotes, now, priceChangesPolicy))
                ConfirmPrices(offer, priceAgreementExpiresOn);
            else
                throw new DomainException();
        }

        private void ConfirmPrices(Offer offer, DateTime priceAgreementExpiresOn) => 
            _priceAgreement = PriceAgreement.Temporary(offer.Quotes, priceAgreementExpiresOn);

        private bool HasSameProductAmountsAs(Offer offer) =>
            _items.Count == offer.Count && offer.ProductAmounts.All(HasMatchingItem);

        private bool HasMatchingItem(ProductAmount productAmount) =>
            !_items.TryGetValue(productAmount.ProductUnit, out var amount)
            || !amount.Equals(productAmount.Amount);

        public void Place(DateTime now)
        {
            if (_isPlaced) return;
            if (!_priceAgreement.IsValidOn(now)) throw new DomainException();
            _isPlaced = true;
        }
    }
}