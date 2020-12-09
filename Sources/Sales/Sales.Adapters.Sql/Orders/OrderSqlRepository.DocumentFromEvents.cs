using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
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
            private readonly Dictionary<OrderId, (OrderDoc Doc, Guid Version)>
                _orders = new Dictionary<OrderId, (OrderDoc, Guid)>();

            private readonly IDocumentSession _session;

            public DocumentFromEvents(IDocumentSession session) => _session = session;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var orderDoc = await _session.LoadAsync<OrderDoc>(id.Value);
                if (orderDoc is null) throw new DomainException();
                var order = RestoreFrom(orderDoc);
                var metadata = await _session.Tenant.MetadataForAsync(orderDoc);
                _orders.Add(id, (orderDoc, metadata.CurrentVersion));
                return order;
            }

            public Task Save(Order order)
            {
                // TODO: document versioning
                var orderDoc = GetOrderDoc(order);
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

            private static Order RestoreFrom(OrderDoc orderDoc)
            {
                var priceAgreementType = orderDoc.PriceAgreementType.ToDomainModel<PriceAgreementType>();
                return priceAgreementType switch
                {
                    PriceAgreementType.Non => RestoreWithNoPriceAgreement(orderDoc),
                    PriceAgreementType.Temporary => RestoreWithTemporaryPriceAgreement(orderDoc),
                    PriceAgreementType.Final => RestoreWithFinalPriceAgreement(orderDoc),
                    _ => throw new ArgumentOutOfRangeException(nameof(priceAgreementType), priceAgreementType, null)
                };
            }

            private static Order RestoreWithNoPriceAgreement(OrderDoc orderDoc) => Order.Restore(
                OrderId.From(orderDoc.Id),
                orderDoc.Items
                    .Select(dbOrderItem => ProductAmount.Of(ProductId.From(dbOrderItem.ProductId),
                        Amount.Of(dbOrderItem.Amount, dbOrderItem.AmountUnit.ToDomainModel<AmountUnit>())))
                    .ToImmutableArray(),
                orderDoc.IsPlaced);

            private static Order RestoreWithTemporaryPriceAgreement(OrderDoc orderDoc)
            {
                if (!orderDoc.PriceAgreementExpiresOn.HasValue) throw new DomainException();
                return Order.Restore(
                    OrderId.From(orderDoc.Id),
                    CreateQuotesFrom(orderDoc.Items),
                    orderDoc.PriceAgreementExpiresOn.Value,
                    orderDoc.IsPlaced);
            }

            private static Order RestoreWithFinalPriceAgreement(OrderDoc orderDoc) => Order.Restore(
                OrderId.From(orderDoc.Id),
                CreateQuotesFrom(orderDoc.Items),
                orderDoc.IsPlaced);

            private static ImmutableArray<Quote> CreateQuotesFrom(IEnumerable<OrderItemDoc> orderItemDocs) =>
                orderItemDocs.Select(orderItemDoc => CreateQuoteFrom(orderItemDoc)).ToImmutableArray();

            private static Quote CreateQuoteFrom(OrderItemDoc orderItemDoc)
            {
                if (!orderItemDoc.Price.HasValue || orderItemDoc.Currency is null) throw new DomainException();
                return Quote.For(
                    ProductAmount.Of(ProductId.From(orderItemDoc.ProductId),
                        Amount.Of(orderItemDoc.Amount, orderItemDoc.AmountUnit.ToDomainModel<AmountUnit>())),
                    Money.Of(orderItemDoc.Price.Value, orderItemDoc.Currency.ToDomainModel<Currency>()));
            }

            private OrderDoc GetOrderDoc(Order order)
            {
                if (_orders.TryGetValue(order.Id, out var orderData))
                    return orderData.Doc;
                return new OrderDoc
                {
                    Id = order.Id.Value,
                    PriceAgreementType = nameof(PriceAgreementType.Non)
                };
            }

            private static void Merge(OrderDoc orderDoc, Order.PricesConfirmed pricesConfirmed)
            {
                orderDoc.PriceAgreementType = nameof(PriceAgreementType.Temporary);
                orderDoc.PriceAgreementExpiresOn = pricesConfirmed.PriceAgreementExpiresOn;
                orderDoc.Items = CreateOrderItemDocsFrom(pricesConfirmed.PriceConfirmations);
            }

            private static void Merge(OrderDoc orderDoc, Order.ProductAmountAdded productAmountAdded)
            {
                orderDoc.PriceAgreementType = nameof(PriceAgreementType.Non);
                orderDoc.Items.ForEach(item =>
                {
                    item.Price = null;
                    item.Currency = null;
                });
                orderDoc.Items.Add(new OrderItemDoc()
                {
                    ProductId = productAmountAdded.ProductId,
                    Amount = productAmountAdded.Amount,
                    AmountUnit = productAmountAdded.AmountUnit,
                    Price = null,
                    Currency = null
                });
            }

            private static void Merge(OrderDoc orderDoc, Order.CreatedFromOffer createdFromOffer)
            {
                orderDoc.PriceAgreementType = nameof(PriceAgreementType.Final);
                orderDoc.PriceAgreementExpiresOn = null;
                orderDoc.Items = CreateOrderItemDocsFrom(createdFromOffer.PriceConfirmations);
                orderDoc.IsPlaced = true;
            }

            private static List<OrderItemDoc> CreateOrderItemDocsFrom(
                ImmutableArray<Order.PriceConfirmation> priceConfirmations) =>
                priceConfirmations
                    .Select(priceConfirmation => new OrderItemDoc
                    {
                        ProductId = priceConfirmation.ProductId,
                        Amount = priceConfirmation.Amount,
                        AmountUnit = priceConfirmation.AmountUnit,
                        Price = priceConfirmation.Price,
                        Currency = priceConfirmation.Currency
                    })
                    .ToList();
            
            private Guid GetCurrentVersionFor(Order order) =>
                _orders.TryGetValue(order.Id, out var orderData) ? orderData.Version : Guid.Empty;

            public class OrderDoc
            {
                public Guid Id { get; set; }
                public List<OrderItemDoc> Items { get; set; } = new List<OrderItemDoc>();
                public string PriceAgreementType { get; set; }
                public DateTime? PriceAgreementExpiresOn { get; set; }
                public bool IsPlaced { get; set; }
            }

            public class OrderItemDoc
            {
                public Guid ProductId { get; set; }
                public int Amount { get; set; }
                public string AmountUnit { get; set; }
                public decimal? Price { get; set; }
                public string Currency { get; set; }
            }
        }
    }
}