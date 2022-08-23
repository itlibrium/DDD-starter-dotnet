using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class DocumentFromEvents : OrderRepository
        {
            private readonly Dictionary<OrderId, (OrderDoc Doc, Guid Version)> _orders = new();

            private readonly IDocumentSession _session;

            public DocumentFromEvents(IDocumentSession session) => _session = session;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var orderDoc = await _session.LoadAsync<OrderDoc>(id.Value);
                if (orderDoc is null) throw new DomainError();
                var order = Order.Restore(OrderId.From(orderDoc.Id), orderDoc.Items, orderDoc.IsPlaced);
                var metadata = await _session.MetadataForAsync(orderDoc);
                _orders.Add(id, (orderDoc, metadata.CurrentVersion));
                return order;
            }

            public Task Save(Order order)
            {
                // TODO: document versioning
                var orderDoc = GetOrderDocFor(order);
                foreach (var newEvent in order.NewEvents)
                {
                    switch (newEvent)
                    {
                        case Order.CreatedFromOffer createdFromOffer:
                            Merge(orderDoc, createdFromOffer);
                            break;
                        case Order.ProductAmountAdded productAmountAdded:
                            Merge(orderDoc, productAmountAdded);
                            break;
                        case Order.PricesConfirmed pricesConfirmed:
                            Merge(orderDoc, pricesConfirmed);
                            break;
                        case Order.Placed _:
                            orderDoc.IsPlaced = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(newEvent), newEvent, null);
                    }
                }
                var version = GetCurrentVersionFor(order);
                _session.Store(orderDoc, version);
                return _session.SaveChangesAsync();
            }

            private OrderDoc GetOrderDocFor(Order order) => _orders.TryGetValue(order.Id, out var orderData)
                ? orderData.Doc
                : new OrderDoc { Id = order.Id.Value };

            private static void Merge(OrderDoc orderDoc, Order.PricesConfirmed pricesConfirmed)
            {
                foreach (var quote in pricesConfirmed.Quotes)
                {
                    var item = orderDoc.GetItemFor(quote.ProductAmount);
                    if (item is null)
                        throw new CorruptedDataError();
                    switch (pricesConfirmed.AgreementType)
                    {
                        case PriceAgreementType.Temporary:
                            item.ConfirmPrice(quote.Price, pricesConfirmed.AgreementExpiresOn!.Value);
                            break;
                        case PriceAgreementType.Final:
                            item.ConfirmPrice(quote.Price);
                            break;
                        case PriceAgreementType.Non:
                            throw new CorruptedDataError();
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            private static void Merge(OrderDoc orderDoc, Order.ProductAmountAdded productAmountAdded)
            {
                var productAmount = productAmountAdded.ProductAmount;
                var item = orderDoc.GetItemFor(productAmount);
                if (item is null)
                    orderDoc.Items.Add(Order.Item.New(productAmount));
                else
                    item.Add(productAmount);
            }

            private static void Merge(OrderDoc orderDoc, Order.CreatedFromOffer createdFromOffer) => 
                orderDoc.Items.AddRange(createdFromOffer.Items);

            private Guid GetCurrentVersionFor(Order order) =>
                _orders.TryGetValue(order.Id, out var orderData) ? orderData.Version : Guid.Empty;

            public class OrderDoc
            {
                public Guid Id { get; set; }
                public List<Order.Item> Items { get; set; } = new();
                public bool IsPlaced { get; set; }

                public Order.Item GetItemFor(ProductAmount productAmount) => 
                    Items.SingleOrDefault(i => i.ProductAmount.Equals(productAmount));
            }
        }
    }
}