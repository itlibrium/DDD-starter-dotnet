using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
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
                if (_orderVersions.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var events = await _session.Events.FetchStreamAsync(id.Value);
                var version = events.Count > 0 ? events[^1].Version : 0;
                _orderVersions.Add(id, version);
                var orderEvents = events
                    .Select(e => e.Data)
                    .Cast<Order.Event>();
                return Order.RestoreFrom(id, orderEvents);
            }

            public async Task Save(Order order)
            {
                // TODO: event versioning
                _session.Events.Append(
                    order.Id.Value,
                    CalculateExpectedVersionFor(order), 
                    order.NewEvents);
                await _session.SaveChangesAsync();
            }

            private int CalculateExpectedVersionFor(Order order) =>
                (_orderVersions.TryGetValue(order.Id, out var version) ? version : 0) + order.NewEvents.Count;
        }
    }
}