using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    public static partial class OrderSqlRepository
    {
        [DddRepository]
        public class TablesFromEvents : OrderRepository
        {
            private readonly Dictionary<OrderId, SalesDb.Order> _orders = new();
            private readonly SalesDbContext _dbContext;

            public TablesFromEvents(SalesDbContext dfContext) => _dbContext = dfContext;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(SameAggregateRestoredMoreThanOnce);
                var dbOrder = await _dbContext.Orders
                    .Include(o => o.Items)
                    .SingleOrDefaultAsync(o => o.Id.Equals(id));
                if (dbOrder is null) throw new DomainError();
                var order = Order.Restore(dbOrder.Id, dbOrder.Items, dbOrder.IsPlaced);
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
                dbOrder.Version++;
                return _dbContext.SaveChangesAsync();
            }

            private SalesDb.Order GetDbOrder(Order order)
            {
                if (_orders.TryGetValue(order.Id, out var dbOrder))
                    return dbOrder;
                dbOrder = new SalesDb.Order
                {
                    Id = order.Id,
                    Items = new List<Order.Item>()
                };
                _dbContext.Orders.Add(dbOrder);
                return dbOrder;
            }

            private static void Merge(SalesDb.Order dbOrder, Order.PricesConfirmed pricesConfirmed)
            {
                foreach (var quote in pricesConfirmed.Quotes)
                {
                    var item = dbOrder.GetItemFor(quote.ProductAmount);
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

            private static void Merge(SalesDb.Order dbOrder, Order.ProductAmountAdded productAmountAdded)
            {
                var productAmount = productAmountAdded.ProductAmount;
                var item = dbOrder.GetItemFor(productAmount);
                if (item is null)
                    dbOrder.Items.Add(Order.Item.New(productAmount));
                else
                    item.Add(productAmount);
            }

            private static void Merge(SalesDb.Order dbOrder, Order.CreatedFromOffer createdFromOffer) => 
                dbOrder.Items.AddRange(createdFromOffer.Items);
        }
    }
}