using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Database.Sql.Raw;
using MyCompany.ECommerce.Sales.Integrations.RiskManagement;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.Persistence;
using RepoDb;

namespace MyCompany.ECommerce.Sales.Orders;

public static partial class OrderSqlRepository
{
    public partial class Raw : Order.Factory, Order.Repository
    {
        private readonly MainDb _db;
        private readonly Dictionary<OrderId, Data> _orders = new();

        public Raw(RiskManagement riskManagement, MainDb db) : base(riskManagement) => _db = db;

        protected override Order.Data CreateData(OrderId id, Money maxTotalCost) => new Data(id, maxTotalCost);

        public async Task<Order> GetBy(OrderId id)
        {
            if (_orders.ContainsKey(id))
                throw new DesignError(SameAggregateRestoredMoreThanOnce);
            var connection = await _db.CreateOneOffConnection();
            var (dbOrders, dbOrderItems) = await connection.QueryMultipleAsync<DbOrder, DbOrderItem>(               
                o => o.Id == id.Value,                
                i => i.OrderId == id.Value);
            var dbOrder = dbOrders.FirstOrDefault();
            if (dbOrder is null)
                throw new DomainError();
            var data = new Data(dbOrder, dbOrderItems);
            var order = Order.RestoreFrom(data);
            _orders.Add(id, data);
            return order;
        }

        public async Task Save(Order order)
        {
            if (!_orders.TryGetValue(order.Id, out var data))
                throw new DesignError(SaveOfUnknownAggregate);
            var transaction = _db.GetCurrentTransaction();
            await data.Save(transaction);
        }
    }
}