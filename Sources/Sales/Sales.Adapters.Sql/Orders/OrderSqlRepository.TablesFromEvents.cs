using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [Stateless]
        [DddRepository]
        public class TablesFromEvents : OrderRepository
        {
            private readonly Dictionary<OrderId, SalesDb.Order> _orders = new Dictionary<OrderId, SalesDb.Order>();
            private readonly SalesDbContext _dbContext;

            public TablesFromEvents(SalesDbContext dfContext) => _dbContext = dfContext;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id == id.Value);
                if (dbOrder is null) throw new DomainException();
                var order = RestoreFrom(dbOrder);
                _orders.Add(id, dbOrder);
                return order;
            }

            public Task Save(Order order)
            {
                var dbOrder = GetDbOrder(order);
                foreach (var newEvent in order.NewEvents)
                {
                    switch (newEvent)
                    {
                        case Order.CreatedFromOffer createdFromOffer:
                            Merge(dbOrder, createdFromOffer);
                            break;
                        case Order.ProductAmountAdded productAmountAdded:
                            Merge(dbOrder, productAmountAdded);
                            break;
                        case Order.PricesConfirmed pricesConfirmed:
                            Merge(dbOrder, pricesConfirmed);
                            break;
                        case Order.Placed _:
                            dbOrder.IsPlaced = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(newEvent), newEvent, null);
                    }
                }
                return _dbContext.SaveChangesAsync();
            }

            private static Order RestoreFrom(SalesDb.Order dbOrder)
            {
                var priceAgreementType = dbOrder.PriceAgreementType.ToDomainModel<PriceAgreementType>();
                return priceAgreementType switch
                {
                    PriceAgreementType.Non => RestoreWithNoPriceAgreement(dbOrder),
                    PriceAgreementType.Temporary => RestoreWithTemporaryPriceAgreement(dbOrder),
                    PriceAgreementType.Final => RestoreWithFinalPriceAgreement(dbOrder),
                    _ => throw new ArgumentOutOfRangeException(nameof(priceAgreementType), priceAgreementType, null)
                };
            }

            private static Order RestoreWithNoPriceAgreement(SalesDb.Order dbOrder) => Order.Restore(
                OrderId.From(dbOrder.Id),
                dbOrder.Items
                    .Select(dbOrderItem => ProductAmount.Of(ProductId.From(dbOrderItem.ProductId),
                        Amount.Of(dbOrderItem.Amount, dbOrderItem.AmountUnit.ToDomainModel<AmountUnit>())))
                    .ToImmutableArray(),
                dbOrder.IsPlaced);

            private static Order RestoreWithTemporaryPriceAgreement(SalesDb.Order dbOrder)
            {
                if (!dbOrder.PriceAgreementExpiresOn.HasValue) throw new DomainException();
                return Order.Restore(
                    OrderId.From(dbOrder.Id),
                    CreateQuotesFrom(dbOrder.Items),
                    dbOrder.PriceAgreementExpiresOn.Value,
                    dbOrder.IsPlaced);
            }

            private static Order RestoreWithFinalPriceAgreement(SalesDb.Order dbOrder) => Order.Restore(
                OrderId.From(dbOrder.Id),
                CreateQuotesFrom(dbOrder.Items),
                dbOrder.IsPlaced);

            private static ImmutableArray<Quote> CreateQuotesFrom(IEnumerable<SalesDb.OrderItem> dbOrderItems) =>
                dbOrderItems.Select(dbOrderItem => CreateQuoteFrom(dbOrderItem)).ToImmutableArray();

            private static Quote CreateQuoteFrom(SalesDb.OrderItem dbOrderItem)
            {
                if (!dbOrderItem.Price.HasValue || dbOrderItem.Currency is null) throw new DomainException();
                return Quote.For(
                    ProductAmount.Of(ProductId.From(dbOrderItem.ProductId),
                        Amount.Of(dbOrderItem.Amount, dbOrderItem.AmountUnit.ToDomainModel<AmountUnit>())),
                    Money.Of(dbOrderItem.Price.Value, dbOrderItem.Currency.ToDomainModel<Currency>()));
            }
            
            private SalesDb.Order GetDbOrder(Order order)
            {
                if (_orders.TryGetValue(order.Id, out var dbOrder)) 
                    return dbOrder;
                dbOrder = new SalesDb.Order
                {
                    Id = order.Id.Value,
                    PriceAgreementType = nameof(PriceAgreementType.Non)
                };
                _dbContext.Orders.Add(dbOrder);
                return dbOrder;
            }
            
            private static void Merge(SalesDb.Order dbOrder, Order.PricesConfirmed pricesConfirmed)
            {
                dbOrder.PriceAgreementType = nameof(PriceAgreementType.Temporary);
                dbOrder.PriceAgreementExpiresOn = pricesConfirmed.PriceAgreementExpiresOn;
                dbOrder.Items = CreateDbOrderItemsFrom(pricesConfirmed.PriceConfirmations);
            }

            private static void Merge(SalesDb.Order dbOrder, Order.ProductAmountAdded productAmountAdded)
            {
                dbOrder.PriceAgreementType = nameof(PriceAgreementType.Non);
                dbOrder.Items.ForEach(item =>
                {
                    item.Price = null;
                    item.Currency = null;
                });
                dbOrder.Items.Add(new SalesDb.OrderItem
                {
                    ProductId = productAmountAdded.ProductId,
                    Amount = productAmountAdded.Amount,
                    AmountUnit = productAmountAdded.AmountUnit,
                    Price = null,
                    Currency = null
                });
            }

            private static void Merge(SalesDb.Order dbOrder, Order.CreatedFromOffer createdFromOffer)
            {
                dbOrder.PriceAgreementType = nameof(PriceAgreementType.Final);
                dbOrder.PriceAgreementExpiresOn = null;
                dbOrder.Items = CreateDbOrderItemsFrom(createdFromOffer.PriceConfirmations);
                dbOrder.IsPlaced = true;
            }
            
            private static List<SalesDb.OrderItem> CreateDbOrderItemsFrom(
                ImmutableArray<Order.PriceConfirmation> priceConfirmations) =>
                priceConfirmations
                    .Select(priceConfirmation => new SalesDb.OrderItem
                    {
                        ProductId = priceConfirmation.ProductId,
                        Amount = priceConfirmation.Amount,
                        AmountUnit = priceConfirmation.AmountUnit,
                        Price = priceConfirmation.Price,
                        Currency = priceConfirmation.Currency
                    })
                    .ToList();
        }
    }
}