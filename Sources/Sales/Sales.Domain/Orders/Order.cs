using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order : IEquatable<Order>
    {
        public OrderId Id { get; }

        private readonly Dictionary<ProductUnit, Amount> _items;
        private PriceAgreement _priceAgreement;
        private bool _isPlaced;

        public IEnumerable<ProductAmount> ProductAmounts =>
            _items.Select(pair => ProductAmount.Of(pair.Key.ProductId, pair.Value));

        public static Order New() => New(OrderId.New());

        public static Order New(OrderId id) => new Order(id,
            new Dictionary<ProductUnit, Amount>(),
            PriceAgreementType.Non,
            ImmutableArray<Quote>.Empty,
            default,
            false);

        public static Order FromOffer(Offer offer)
        {
            var order = New();
            order.AddAndApply(new CreatedFromOffer(CreatePriceConfirmationsFrom(offer.Quotes)));
            return order;

            // Version without events:
            // foreach (var productAmount in offer.ProductAmounts)
            //     order.AddItem(productAmount.ProductUnit, productAmount.Amount);
            // order._priceAgreement = PriceAgreement.Final(offer.Quotes);
            // order._isPlaced = true;
            // return order;
        }

        public static Order Restore(OrderId id,
            ImmutableArray<ProductAmount> productAmounts,
            bool isPlaced) => new Order(id,
            productAmounts
                .ToDictionary(productAmount => productAmount.ProductUnit, productAmount => productAmount.Amount),
            PriceAgreementType.Non,
            ImmutableArray<Quote>.Empty,
            default,
            isPlaced);

        public static Order Restore(OrderId id,
            ImmutableArray<Quote> quotes,
            DateTime priceAgreementExpiresOn,
            bool isPlaced) => new Order(id,
            quotes
                .Select(quote => quote.ProductAmount)
                .ToDictionary(productAmount => productAmount.ProductUnit, productAmount => productAmount.Amount),
            PriceAgreementType.Temporary,
            quotes,
            priceAgreementExpiresOn,
            isPlaced);

        public static Order Restore(OrderId id,
            ImmutableArray<Quote> quotes,
            bool isPlaced) => new Order(id,
            quotes
                .Select(quote => quote.ProductAmount)
                .ToDictionary(productAmount => productAmount.ProductUnit, productAmount => productAmount.Amount),
            PriceAgreementType.Final,
            quotes,
            default,
            isPlaced);

        private Order(OrderId id,
            Dictionary<ProductUnit, Amount> items,
            PriceAgreementType priceAgreementType,
            ImmutableArray<Quote> quotes,
            DateTime priceAgreementExpiresOn,
            bool isPlaced)
        {
            Id = id;
            _items = items;
            _priceAgreement = priceAgreementType switch
            {
                PriceAgreementType.Non => PriceAgreement.Non(),
                PriceAgreementType.Temporary => PriceAgreement.Temporary(quotes, priceAgreementExpiresOn),
                PriceAgreementType.Final => PriceAgreement.Final(quotes),
                _ => throw new ArgumentOutOfRangeException(nameof(priceAgreementType), priceAgreementType, null)
            };
            _isPlaced = isPlaced;
        }

        public void Add(ProductAmount productAmount)
        {
            if (_isPlaced) throw new DomainException();
            AddAndApply(new ProductAmountAdded(productAmount.ProductId.Value,
                productAmount.Amount.Unit.ToCode(),
                productAmount.Amount.Value));

            // Version without events:
            // AddItem(productAmount.ProductUnit, productAmount.Amount);
        }

        private void AddItem(ProductUnit productUnit, Amount amount)
        {
            if (_items.TryGetValue(productUnit, out var currentAmount))
                _items[productUnit] = currentAmount + amount;
            else
                _items.Add(productUnit, amount);
            _priceAgreement = PriceAgreement.Non();
        }

        public void ConfirmPrices(Offer offer, DateTime priceAgreementExpiresOn, DateTime now,
            PriceChangesPolicy priceChangesPolicy)
        {
            if (_isPlaced) throw new DomainException();
            var quotes = offer.Quotes;
            if (!HasSameProductAmountsAs(quotes)) throw new DomainException();
            if (!_priceAgreement.CanChangePrices(quotes, now, priceChangesPolicy)) throw new DomainException();
            AddAndApply(new PricesConfirmed(priceAgreementExpiresOn, CreatePriceConfirmationsFrom(quotes)));

            // Version without events:
            // _priceAgreement = PriceAgreement.Temporary(quotes, priceAgreementExpiresOn);
        }

        private bool HasSameProductAmountsAs(ImmutableArray<Quote> quotes) =>
            _items.Count == quotes.Length && quotes.Select(quote => quote.ProductAmount).All(HasMatchingItem);

        private bool HasMatchingItem(ProductAmount productAmount) =>
            _items.TryGetValue(productAmount.ProductUnit, out var amount) &&
            amount.Equals(productAmount.Amount);

        public void Place(DateTime now)
        {
            if (_isPlaced) return;
            if (!_priceAgreement.IsValidOn(now)) throw new DomainException();
            AddAndApply(new Placed());

            // Version without events:
            // _isPlaced = true;
        }
        
        private static ImmutableArray<PriceConfirmation> CreatePriceConfirmationsFrom(ImmutableArray<Quote> quotes) =>
            quotes
                .Select(quote => new PriceConfirmation(
                    quote.ProductAmount.ProductId.Value,
                    quote.ProductAmount.Amount.Value,
                    quote.ProductAmount.Amount.Unit.ToCode(),
                    quote.Price.Value, quote.Price.Currency.ToCode()))
                .ToImmutableArray();

        public bool Equals(Order other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id) &&
                   _isPlaced == other._isPlaced &&
                   _items.HasSameItemsAs(other._items) &&
                   _priceAgreement.Equals(other._priceAgreement);
        }

        public override bool Equals(object obj) => obj is Order other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}