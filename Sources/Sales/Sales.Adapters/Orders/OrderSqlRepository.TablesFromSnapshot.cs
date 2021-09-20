using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class TablesFromSnapshot : OrderRepository
        {
            private readonly Dictionary<OrderId, SalesDb.Order> _orders = new Dictionary<OrderId, SalesDb.Order>();
            private readonly SalesDbContext _dbContext;

            public TablesFromSnapshot(SalesDbContext dbContext) => _dbContext = dbContext;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id == id.Value);
                if (dbOrder is null) throw new DomainError();
                var snapshot = CreateSnapshotFrom(dbOrder);
                var order = Order.RestoreFrom(snapshot);
                _orders.Add(id, dbOrder);
                return order;
            }

            public Task Save(Order order)
            {
                var dbOrder = GetDbOrder(order);
                var snapshot = order.GetSnapshot();
                Merge(dbOrder, snapshot);
                return _dbContext.SaveChangesAsync();
            }

            private static Order.Snapshot CreateSnapshotFrom(SalesDb.Order dbOrder) => new Order.Snapshot(
                dbOrder.Id,
                dbOrder.Items
                    .Select(dbOrderItem => new Order.Snapshot.Item(
                        dbOrderItem.ProductId,
                        dbOrderItem.Amount,
                        dbOrderItem.AmountUnit,
                        dbOrderItem.Price,
                        dbOrderItem.Currency))
                    .ToImmutableArray(),
                dbOrder.PriceAgreementType,
                dbOrder.PriceAgreementExpiresOn,
                dbOrder.IsPlaced);

            private SalesDb.Order GetDbOrder(Order order)
            {
                if (_orders.TryGetValue(order.Id, out var dbOrder)) 
                    return dbOrder;
                dbOrder = new SalesDb.Order {Id = order.Id.Value};
                _dbContext.Orders.Add(dbOrder);
                return dbOrder;
            }
            
            private static void Merge(SalesDb.Order dbOrder, Order.Snapshot snapshot)
            {
                dbOrder.Items = snapshot.Items
                    .Select(item => new SalesDb.OrderItem
                    {
                        ProductId = item.ProductId,
                        Amount = item.Amount,
                        AmountUnit = item.AmountUnit,
                        Price = item.Price,
                        Currency = item.Currency
                    })
                    .ToList();
                dbOrder.PriceAgreementType = snapshot.PriceAgreementType;
                dbOrder.PriceAgreementExpiresOn = snapshot.PriceAgreementExpiresOn;
                dbOrder.IsPlaced = snapshot.IsPlaced;
            }
        }
    }
}