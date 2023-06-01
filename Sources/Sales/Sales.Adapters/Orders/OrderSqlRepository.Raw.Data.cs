using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Database.Sql.Raw;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using MyCompany.ECommerce.TechnicalStuff.Persistence.RepoDb;
using RepoDb;

namespace MyCompany.ECommerce.Sales.Orders;

public static partial class OrderSqlRepository
{
    public partial class Raw
    {
        public class Data : RootEntityData<DbOrder, Guid>, Order.Data
        {
            public OrderId Id { get; }
            public Money MaxTotalCost { get; }
            public bool IsPlaced { get; set; }

            private readonly TrackedSet<Order.Item, DbOrderItem> _items;
            public IReadOnlyCollection<Order.Item> Items => _items;

            public Data(DbOrder originalDbOrder, IEnumerable<DbOrderItem> originalDbOrderItems)
                : base(originalDbOrder)
            {
                Id = new OrderId(originalDbOrder.Id);
                IsPlaced = originalDbOrder.IsPlaced;
                _items = CreateItemsSet(originalDbOrder.Id, originalDbOrderItems);
            }

            public Data(OrderId id, Money maxTotalCost)
                : base(null)
            {
                Id = id;
                MaxTotalCost = maxTotalCost;
                IsPlaced = false;
                _items = CreateItemsSet(Id.Value, Enumerable.Empty<DbOrderItem>());
            }

            private static TrackedSet<Order.Item, DbOrderItem> CreateItemsSet(Guid id,
                IEnumerable<DbOrderItem> dbOrderItems) => new(dbOrderItems,
                item => new DbOrderItem
                {
                    OrderId = id,
                    ProductId = item.ProductAmount.ProductId.Value,
                    AmountUnit = item.ProductAmount.Amount.Unit.ToString(),
                    AmountValue = item.ProductAmount.Amount.Value,
                    PriceAgreementType = item.PriceAgreement.Type.ToString(),
                    Price = item.PriceAgreement.Price?.Value,
                    Currency = item.PriceAgreement.Price?.Currency.ToString(),
                    PriceAgreementExpiresOn = item.PriceAgreement.ExpiresOn
                },
                dbItem => new Order.Item(
                    new ProductAmount(
                        ProductId.From(dbItem.ProductId),
                        Amount.Of(
                            dbItem.AmountValue,
                            dbItem.AmountUnit.ToDomainModel<AmountUnit>())),
                    new Order.PriceAgreement(
                        dbItem.PriceAgreementType.ToDomainModel<PriceAgreementType>(),
                        dbItem.Price.HasValue
                            ? Money.Of(dbItem.Price.Value, dbItem.Currency.ToDomainModel<Currency>())
                            : null,
                        dbItem.PriceAgreementExpiresOn)));

            public void Add(Order.Item item) => _items.Add(item);

            public void Remove(Order.Item item) => _items.Remove(item);

            protected override DbOrder ToDbEntity(int version) => new(Id.Value, IsPlaced, version);

            protected override async Task SaveNestedDbEntities(IDbTransaction transaction)
            {
                var (added, updated, deleted) = _items.GetDiff();
                await transaction.Connection.InsertAllAsync(added, transaction: transaction);
                await transaction.Connection.UpdateAllAsync(updated,
                    qualifiers: i => new { i.OrderId, i.ProductId, i.AmountUnit }, 
                    transaction: transaction);
                await transaction.Connection.DeleteAllAsync(deleted, transaction: transaction);
            }
        }
    }
}