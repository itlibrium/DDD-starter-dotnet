using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Database;
using MyCompany.Crm.Sales.Database.Sql.Raw;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using RepoDb;

namespace MyCompany.Crm.Sales.Orders;

public static partial class OrderSqlRepository
{
    [DddRepository]
    public class Raw : OrderRepository
    {
        private readonly SalesDb _salesDb;
        private readonly Dictionary<OrderId, OrderData> _orders = new();
        
        public Raw(SalesDb salesDb) => _salesDb = salesDb;

        public Order New()
        {
            var data = new OrderData();
            _orders.Add(data.Id, data);
            return Order.RestoreFrom(data);
        }

        public async Task<Order> GetBy(OrderId id)
        {
            if (_orders.ContainsKey(id))
                throw new DesignError(SameAggregateRestoredMoreThanOnce);
            var connection = await _salesDb.GetCurrentConnection();
            var (dbOrders, dbOrderItems) = await connection.QueryMultipleAsync<DbOrder, DbOrderItem>(               
                o => o.Id == id.Value,                
                i => i.OrderId == id.Value);
            var dbOrder = dbOrders.FirstOrDefault();
            if (dbOrder is null)
                throw new DomainError();
            var data = new OrderData(dbOrder, dbOrderItems);
            var order = Order.RestoreFrom(data);
            _orders.Add(id, data);
            return order;
        }

        public async Task Save(Order order)
        {
            if (!_orders.TryGetValue(order.Id, out var data))
                throw new DesignError(SaveOfUnknownAggregate);
            var transaction = _salesDb.GetCurrentTransaction();
            await data.Save(transaction);
        }
    }
}