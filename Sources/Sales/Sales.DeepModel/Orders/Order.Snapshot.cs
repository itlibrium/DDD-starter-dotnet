using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        public Snapshot GetSnapshot() => new Snapshot(Id.Value,
            CreateOrderItems(_items).ToImmutableArray(),
            _priceAgreement.Type.ToCode(),
            _priceAgreement.ExpiresOn,
            _isPlaced);

        private IEnumerable<Snapshot.Item> CreateOrderItems(IEnumerable<KeyValuePair<ProductUnit, Amount>> items)
        {
            foreach (var (productUnit, amount) in items)
            {
                var productAmount = ProductAmount.Of(productUnit.ProductId, amount);
                var price = _priceAgreement.GetPrice(productAmount);
                yield return new Snapshot.Item(productUnit.ProductId.Value,
                    amount.Value,
                    amount.Unit.ToCode(),
                    price?.Value,
                    price?.Currency.ToCode());
            }
        }

        public static Order RestoreFrom(Snapshot snapshot)
        {
            var priceAgreementType = snapshot.PriceAgreementType.ToDomainModel<PriceAgreementType>();
            return priceAgreementType switch
            {
                PriceAgreementType.Non => RestoreWithNoPriceAgreement(snapshot),
                PriceAgreementType.Temporary => RestoreWithTemporaryPriceAgreement(snapshot),
                PriceAgreementType.Final => RestoreWithFinalPriceAgreement(snapshot),
                _ => throw new ArgumentOutOfRangeException(nameof(priceAgreementType), priceAgreementType, null)
            };
        }

        private static Order RestoreWithNoPriceAgreement(Snapshot snapshot) => Restore(
            OrderId.From(snapshot.Id),
            snapshot.Items
                .Select(orderItemData => ProductAmount.Of(ProductId.From(orderItemData.ProductId),
                    Amount.Of(orderItemData.Amount, orderItemData.AmountUnit.ToDomainModel<AmountUnit>())))
                .ToImmutableArray(),
            snapshot.IsPlaced);

        private static Order RestoreWithTemporaryPriceAgreement(Snapshot orderData)
        {
            if (!orderData.PriceAgreementExpiresOn.HasValue) throw new DomainError();
            return Restore(
                OrderId.From(orderData.Id),
                CreateQuotesFrom(orderData.Items),
                orderData.PriceAgreementExpiresOn.Value,
                orderData.IsPlaced);
        }

        private static Order RestoreWithFinalPriceAgreement(Snapshot orderData) => Restore(
            OrderId.From(orderData.Id),
            CreateQuotesFrom(orderData.Items),
            orderData.IsPlaced);

        private static ImmutableArray<Quote> CreateQuotesFrom(IEnumerable<Snapshot.Item> orderItemsData) =>
            orderItemsData.Select(orderItemData => CreateQuoteFrom(orderItemData)).ToImmutableArray();

        private static Quote CreateQuoteFrom(Snapshot.Item item)
        {
            if (!item.Price.HasValue || item.Currency is null) throw new DomainError();
            return Quote.For(
                ProductAmount.Of(ProductId.From(item.ProductId),
                    Amount.Of(item.Amount, item.AmountUnit.ToDomainModel<AmountUnit>())),
                Money.Of(item.Price.Value, item.Currency.ToDomainModel<Currency>()));
        }

        public class Snapshot
        {
            public Guid Id { get; }
            public ImmutableArray<Item> Items { get; }
            public string PriceAgreementType { get; }
            public DateTime? PriceAgreementExpiresOn { get; }
            public bool IsPlaced { get; }

            public Snapshot(Guid id,
                ImmutableArray<Item> items,
                string priceAgreementType,
                DateTime? priceAgreementExpiresOn,
                bool isPlaced)
            {
                Id = id;
                Items = items;
                PriceAgreementType = priceAgreementType;
                PriceAgreementExpiresOn = priceAgreementExpiresOn;
                IsPlaced = isPlaced;
            }

            public class Item
            {
                public Guid ProductId { get; }
                public int Amount { get; }
                public string AmountUnit { get; }
                public decimal? Price { get; }
                public string Currency { get; }

                public Item(Guid productId, int amount, string amountUnit, decimal? price, string currency)
                {
                    ProductId = productId;
                    Amount = amount;
                    AmountUnit = amountUnit;
                    Price = price;
                    Currency = currency;
                }
            }
        }
    }
}