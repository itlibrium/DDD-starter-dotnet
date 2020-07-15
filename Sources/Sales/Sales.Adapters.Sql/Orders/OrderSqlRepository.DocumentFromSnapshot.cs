using System.Threading.Tasks;
using Marten;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        public class DocumentFromSnapshot : OrderRepository
        {
            private readonly IDocumentSession _session;

            public DocumentFromSnapshot(IDocumentSession session) => _session = session;

            public async Task<Order> GetBy(OrderId id)
            {
                var snapshot = await _session.LoadAsync<Order.Snapshot>(id.Value);
                if (snapshot is null) throw new DomainException();
                return Order.RestoreFrom(snapshot);
            }
            
            public Task Save(Order order)
            {
                // TODO: optimistic locking
                // TODO: document versioning
                var snapshot = order.GetSnapshot();
                _session.Store(snapshot);
                return _session.SaveChangesAsync();
            }
        }
    }
}