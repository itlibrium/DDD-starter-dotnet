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
            private readonly Dictionary<OrderId, SalesDb.Order> _orders = new();
            private readonly SalesDbContext _dbContext;

            public TablesFromSnapshot(SalesDbContext dbContext) => _dbContext = dbContext;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id.Equals(id));
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
                dbOrder.Version++;
                return _dbContext.SaveChangesAsync();
            }

            private static Order.Snapshot CreateSnapshotFrom(SalesDb.Order dbOrder) =>
                new(dbOrder.Id.Value, dbOrder.Items.ToImmutableArray(), dbOrder.IsPlaced);

            private SalesDb.Order GetDbOrder(Order order)
            {
                if (_orders.TryGetValue(order.Id, out var dbOrder))
                    return dbOrder;
                dbOrder = new SalesDb.Order { Id = order.Id };
                _dbContext.Orders.Add(dbOrder);
                return dbOrder;
            }

            private static void Merge(SalesDb.Order dbOrder, Order.Snapshot snapshot)
            {
                dbOrder.Items = snapshot.Items.ToList();
                dbOrder.IsPlaced = snapshot.IsPlaced;
            }
        }
    }
}