using JetBrains.Annotations;
using Marten;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Integrations.RiskManagement;
using MyCompany.ECommerce.TechnicalStuff;

namespace MyCompany.ECommerce.Sales.Orders;

public static partial class OrderSqlRepository
{
    public partial class EventsSourcing([NotNull] RiskManagement riskManagement, IDocumentSession session)
        : Order.Factory(riskManagement), Order.Repository
    {
        public static readonly IEnumerable<(Type Type, string Name)> Events = new[]
        {
            (typeof(Order.CreatedFromOffer), "Order.CreatedFromOffer"),
            (typeof(Order.ProductAmountAdded), "Order.ProductAmountAdded"),
            (typeof(Order.PricesConfirmed), "Order.PricesConfirmed"),
            (typeof(Order.Placed), "Order.Placed")
        };

        private readonly Dictionary<OrderId, long> _orderVersions = new();

        protected override Order.Data CreateData(OrderId id, Money maxTotalCost) => new Data { Id = id };

        public async Task<Order> GetBy(OrderId id)
        {
            if (_orderVersions.ContainsKey(id))
                throw new DesignError(SameAggregateRestoredMoreThanOnce);
            var events = await session.Events.FetchStreamAsync(id.Value);
            var version = events.Count > 0 ? events[^1].Version : 0;
            _orderVersions.Add(id, version);
            var orderEvents = events
                .Select(e => e.Data)
                .Cast<Order.Event>();
            var order = Order.RestoreFrom(new Data { Id = id });
            foreach (var orderEvent in orderEvents)
                orderEvent.Apply(order);
            return order;
        }

        public async Task Save(Order order)
        {
            // TODO: event versioning
            session.Events.Append(
                order.Id.Value,
                CalculateExpectedVersionFor(order),
                order.NewEvents);
            await session.SaveChangesAsync();
        }

        private long CalculateExpectedVersionFor(Order order) =>
            (_orderVersions.TryGetValue(order.Id, out var version) ? version : 0) + order.NewEvents.Count;
    }
}