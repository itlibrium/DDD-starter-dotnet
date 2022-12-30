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

            private readonly Dictionary<OrderId, long> _orderVersions = new();
            private readonly IDocumentSession _session;

            public EventsSourcing(IDocumentSession documentSession) => _session = documentSession;

            public Order New()
            {
                var id = OrderId.New();
                var order = Create(id);
                return order;
            }
            
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
                var order = Create(id);
                foreach (var orderEvent in orderEvents)
                    orderEvent.Apply(order);
                return order;
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
            
            private static Order Create(OrderId id) => Order.RestoreFrom(new Data { Id = id });

            private long CalculateExpectedVersionFor(Order order) =>
                (_orderVersions.TryGetValue(order.Id, out var version) ? version : 0) + order.NewEvents.Count;
        }
        
        private class Data : Order.Data
        {
            public OrderId Id { get; init; }
            public bool IsPlaced { get; set; }
            private List<Order.Item> Items { get; } = new();

            IReadOnlyCollection<Order.Item> Order.Data.Items => Items;
            public void Add(Order.Item item) => Items.Add(item);
            public void Remove(Order.Item item) => Items.Remove(item);
        }
    }
}