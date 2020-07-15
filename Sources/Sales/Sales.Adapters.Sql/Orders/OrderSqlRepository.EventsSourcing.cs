using System;
using System.Threading.Tasks;
using Marten;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        public class EventsSourcing : OrderRepository
        {
            private readonly IDocumentSession _session;
            
            public EventsSourcing(IDocumentSession documentSession) => _session = documentSession;

            public Task<Order> GetBy(OrderId id) => throw new NotImplementedException();

            public Task Save(Order order)
            {
                // TODO: optimistic locking
                // TODO: event versioning
                _session.Events.Append(order.Id.Value, order.NewEvents);
                return _session.SaveChangesAsync();
            }
        }
    }
}