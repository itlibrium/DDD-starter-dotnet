using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    [DddAggregate]
    public partial class Order : IEquatable<Order>
    {
        public OrderId Id { get; }

        private readonly Dictionary<ProductUnit, Item> _items;
        private bool _isPlaced;
        
        public IEnumerable<ProductAmount> ProductAmounts => _items.Values.Select(item => item.ProductAmount);

        public static Order New() => New(OrderId.New());

        public static Order New(OrderId id) => new(id, Enumerable.Empty<Item>(), false);

        public static Order FromOffer(Offer offer)
        {
            var order = New();
            var items = offer.Quotes
                .Select(quote => new Item(quote.ProductAmount, PriceAgreement.Final(quote.Price)))
                .ToImmutableArray();
            order.AddAndApply(new CreatedFromOffer(items));
            order.AddAndApply(new Placed());
            return order;

            // Version without events:
            // foreach (var quote in offer.Quotes)
            //     order._items[quote.ProductAmount.ProductUnit] = Item.New(quote.ProductAmount)
            //         .With(PriceAgreement.Final(quote.Price));
            // order._isPlaced = true;
            // return order;
        }

        public static Order Restore(OrderId id, IEnumerable<Item> items, bool isPlaced) => new(id, items, isPlaced);

        private Order(OrderId id,
            IEnumerable<Item> items,
            bool isPlaced)
        {
            Id = id;
            _items = items.ToDictionary(item => item.ProductAmount.ProductUnit);
            _isPlaced = isPlaced;
        }

        public void Add(ProductAmount productAmount)
        {
            if (_isPlaced)
                throw new DomainError();
            AddAndApply(new ProductAmountAdded(productAmount));

            // Version without events:
            // AddToItem(productAmount);
        }

        private void AddToItem(ProductAmount productAmount)
        {
            var productUnit = productAmount.ProductUnit;
            if (_items.TryGetValue(productUnit, out var item))
                item.Add(productAmount);
            else
                _items.Add(productUnit, Item.New(productAmount));
        }

        public void ConfirmPrices(Offer offer, PriceChangesPolicy priceChangesPolicy) =>
            ConfirmPrice(offer.Quotes, priceChangesPolicy, PriceAgreementType.Final, default);

        public void ConfirmPrices(Offer offer, PriceChangesPolicy priceChangesPolicy, DateTime agreementExpiresOn) =>
            ConfirmPrice(offer.Quotes, priceChangesPolicy, PriceAgreementType.Temporary, agreementExpiresOn);

        private void ConfirmPrice(ImmutableArray<Quote> newQuotes,
            PriceChangesPolicy priceChangesPolicy,
            PriceAgreementType agreementType,
            DateTime? agreementExpiresOn)
        {
            if (_isPlaced)
                throw new DomainError();
            if (!newQuotes.All(quote => HasMatchingItemFor(quote.ProductAmount)))
                throw new DomainError();
            if (!newQuotes.All(quote => CanChangePriceFor(quote.ProductAmount)))
                throw new DomainError();
            var oldQuotes = _items.Values
                .Where(i => i.PriceAgreement.Type != PriceAgreementType.Non)
                .Select(i => Quote.For(i.ProductAmount, i.PriceAgreement.Price!))
                .ToImmutableArray();
            if (!priceChangesPolicy.CanChangePrices(oldQuotes, newQuotes))
                throw new DomainError();
            AddAndApply(new PricesConfirmed(newQuotes, agreementType, agreementExpiresOn));

            // Version without events:
            // ApplyPriceAgreements(newQuotes, agreementType, agreementExpiresOn);
        }

        private bool HasMatchingItemFor(ProductAmount productAmount) =>
            _items.TryGetValue(productAmount.ProductUnit, out var item) &&
            item.ProductAmount.Equals(productAmount);

        private bool CanChangePriceFor(ProductAmount productAmount) =>
            _items.TryGetValue(productAmount.ProductUnit, out var item) &&
            item.PriceAgreement.CanChangePrice();

        private void ApplyPriceAgreements(ImmutableArray<Quote> quotes, PriceAgreementType agreementType,
            DateTime? agreementExpiresOn)
        {
            foreach (var quote in quotes)
            {
                var productUnit = quote.ProductAmount.ProductUnit;
                if (!_items.TryGetValue(productUnit, out var item))
                    throw new CorruptedDataError();
                switch (agreementType)
                {
                    case PriceAgreementType.Temporary:
                        item.ConfirmPrice(quote.Price, agreementExpiresOn!.Value);
                        break;
                    case PriceAgreementType.Final:
                        item.ConfirmPrice(quote.Price);
                        break;
                    case PriceAgreementType.Non:
                        throw new CorruptedDataError();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Place(DateTime now)
        {
            if (_isPlaced) return;
            if (!AllItemsHaveValidPriceAgreementOn(now)) throw new DomainError();
            AddAndApply(new Placed());

            // Version without events:
            // _isPlaced = true;
        }

        private bool AllItemsHaveValidPriceAgreementOn(DateTime date) =>
            _items.Values.All(item => item.PriceAgreement.IsValidOn(date));

        public bool Equals(Order? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id) &&
                   _isPlaced == other._isPlaced &&
                   _items.HasSameItemsAs(other._items, (x, y) => x.ProductAmount.Equals(y.ProductAmount) &&
                                                                 x.PriceAgreement.Equals(y.PriceAgreement));
        }

        public override bool Equals(object? obj) => obj is Order other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}