using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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