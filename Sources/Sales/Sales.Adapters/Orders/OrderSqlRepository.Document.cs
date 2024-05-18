using JetBrains.Annotations;
using Marten;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Database.Sql.Documents;
using MyCompany.ECommerce.Sales.Integrations.RiskManagement;
using MyCompany.ECommerce.TechnicalStuff;

namespace MyCompany.ECommerce.Sales.Orders;

public static partial class OrderSqlRepository
{
    public class Document : Order.Factory, Order.Repository
    {
        private readonly Dictionary<OrderId, (DbOrder OrderData, Guid Version)> _orders = new();
        private readonly IDocumentSession _session;

        public Document([NotNull] RiskManagement riskManagement, IDocumentSession session) : base(riskManagement) => 
            _session = session;

        protected override Order.Data CreateData(OrderId id, Money maxTotalCost)
        {
            var dbOrder = new DbOrder { Id = id.Value, Items = new List<Order.Item>() };
            _orders.Add(id, (dbOrder, Guid.Empty));
            return dbOrder;
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
            _session.UpdateExpectedVersion(tuple.OrderData, tuple.Version);
            return _session.SaveChangesAsync();
        }
    }
}