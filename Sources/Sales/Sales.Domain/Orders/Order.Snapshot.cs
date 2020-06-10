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
            CreateOrderItems(_items).ToImmutableList(),
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
                    amount.Unit.ToCode(),
                    amount.Value,
                    price?.Value,
                    price?.Currency.ToCode());
            }
        }

        public class Snapshot
        {
            public Guid Id { get; }
            public IImmutableList<Item> Items { get; }
            public string PriceAgreementType { get; }
            public DateTime? PriceAgreementExpiresOn { get; }
            public bool IsPlaced { get; }

            public Snapshot(Guid id, 
                IImmutableList<Item> items, 
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
                public string AmountUnit { get; }
                public int Amount { get; }
                public decimal? Price { get; }
                public string Currency { get; }

                public Item(Guid productId, string amountUnit, int amount, decimal? price, string currency)
                {
                    ProductId = productId;
                    AmountUnit = amountUnit;
                    Amount = amount;
                    Price = price;
                    Currency = currency;
                }
            }
        }
    }
}