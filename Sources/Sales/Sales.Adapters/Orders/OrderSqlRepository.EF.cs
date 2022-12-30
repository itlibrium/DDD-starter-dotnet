using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Database.Sql.EF;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class EF : OrderRepository
        {
            private readonly Dictionary<OrderId, DbOrder> _orders = new();
            private readonly SalesDbContext _dbContext;

            public EF(SalesDbContext dbContext) => _dbContext = dbContext;

            public Order New()
            {
                var id = OrderId.New();
                var dbOrder = new DbOrder { Id = id, Items = new List<Order.Item>() };
                _orders.Add(id, dbOrder);
                _dbContext.Orders.Add(dbOrder);
                return Order.RestoreFrom(dbOrder);
            }

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id.Equals(id));
                if (dbOrder is null) throw new DomainError();
                var order = Order.RestoreFrom(dbOrder);
                _orders.Add(id, dbOrder);
                return order;
            }

            public Task Save(Order order)
            {
                if (!_orders.TryGetValue(order.Id, out var dbOrder))
                    throw new DesignError(SaveOfUnknownAggregate);
                dbOrder.Version++;
                return _dbContext.SaveChangesAsync();
                // TODO: error when not all tracked orders are explicitly saved
            }
        }
    }
}