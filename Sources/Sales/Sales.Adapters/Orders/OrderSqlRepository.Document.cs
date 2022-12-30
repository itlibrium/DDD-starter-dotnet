using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.Sales.Database.Sql.Documents;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class Document : OrderRepository
        {
            private readonly Dictionary<OrderId, (DbOrder OrderData, Guid Version)> _orders = new();
            private readonly IDocumentSession _session;

            public Document(IDocumentSession session) => _session = session;

            public Order New()
            {
                var id = OrderId.New();
                var orderDoc = new DbOrder { Id = id.Value, Items = new List<Order.Item>() };
                _orders.Add(id, (orderDoc, Guid.Empty));
                return Order.RestoreFrom(orderDoc);
            }

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var orderDoc = await _session.LoadAsync<DbOrder>(id.Value);
                if (orderDoc is null)
                    throw new DomainError();
                var order = Order.RestoreFrom(orderDoc);
                var metadata = await _session.MetadataForAsync(orderDoc);
                _orders.Add(id, (orderDoc, metadata.CurrentVersion));
                return order;
            }

            public Task Save(Order order)
            {
                // TODO: document versioning
                if (!_orders.TryGetValue(order.Id, out var tuple))
                    throw new DesignError(SaveOfUnknownAggregate);
                _session.Store(tuple.OrderData, tuple.Version);
                return _session.SaveChangesAsync();
            }
        }
    }
}