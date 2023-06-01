using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Database.Sql.EF;
using MyCompany.ECommerce.Sales.Integrations.RiskManagement;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class EF : Order.Factory, Order.Repository
        {
            private readonly Dictionary<OrderId, DbOrder> _orders = new();
            private readonly SalesDbContext _dbContext;

            public EF([NotNull] RiskManagement riskManagement, SalesDbContext dbContext) : base(riskManagement) => 
                _dbContext = dbContext;

            protected override Order.Data CreateData(OrderId id, Money maxTotalCost)
            {
                var dbOrder = new DbOrder
                {
                    Id = id,
                    MaxTotalCost = maxTotalCost,
                    Items = new List<Order.Item>()
                };
                _orders.Add(id, dbOrder);
                _dbContext.Orders.Add(dbOrder);
                return dbOrder;
            }

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id.Equals(id));
                if (dbOrder is null) 
                    throw new DomainError();
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