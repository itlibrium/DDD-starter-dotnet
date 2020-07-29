using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [Stateless]
        [DddRepository]
        public class EventsSourcing : OrderRepository
        {
            public static readonly IEnumerable<(Type Type, string Name)> Events = new[]
            {
                (typeof(Order.CreatedFromOffer), "Order.CreatedFromOffer"),
                (typeof(Order.ProductAmountAdded), "Order.ProductAmountAdded"),
                (typeof(Order.PricesConfirmed), "Order.PricesConfirmed"),
                (typeof(Order.Placed), "Order.Placed")
            };

            private readonly Dictionary<OrderId, int> _orderVersions = new Dictionary<OrderId, int>();
            private readonly IDocumentSession _session;

            public EventsSourcing(IDocumentSession documentSession) => _session = documentSession;

            public async Task<Order> GetBy(OrderId id)
            {
                var events = (await _session.Events.FetchStreamAsync(id.Value))
                    .Select(e => e.Data)
                    .Cast<Order.Event>();
                return Order.RestoreFrom(id, events);
            }

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