using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class DocumentFromSnapshot : OrderRepository
        {
            private readonly Dictionary<OrderId, Guid> _orderVersions = new Dictionary<OrderId, Guid>();
            private readonly IDocumentSession _session;

            public DocumentFromSnapshot(IDocumentSession session) => _session = session;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orderVersions.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var snapshot = await _session.LoadAsync<Order.Snapshot>(id.Value);
                if (snapshot is null) 
                    throw new DomainException();
                var order = Order.RestoreFrom(snapshot);
                var metadata = await _session.Tenant.MetadataForAsync(snapshot);
                _orderVersions.Add(id, metadata.CurrentVersion);
                return order;
            }
            
            public Task Save(Order order)
            {
                // TODO: document versioning
                var snapshot = order.GetSnapshot();
                var version = GetCurrentVersionFor(order);
                _session.Store(snapshot, version);
                return _session.SaveChangesAsync();
            }

            private Guid GetCurrentVersionFor(Order order) =>
                _orderVersions.TryGetValue(order.Id, out var version) ? version : Guid.Empty;
        }
    }
}