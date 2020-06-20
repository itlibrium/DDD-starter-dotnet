using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class OrderSqlRepository
    {
        private class TablesFromEvents : OrderRepository
        {
            private readonly Dictionary<OrderId, OrderData> _orders = new Dictionary<OrderId, OrderData>();
            private readonly SalesDbContext _dbContext;

            public TablesFromEvents(SalesDbContext dbContext) => _dbContext = dbContext;

            public async Task<Order> GetBy(OrderId id)
            {
                if (_orders.ContainsKey(id))
                    throw new DesignError(
                        "Same aggregate is restored from the repository more than once in a single business transaction");
                var data = await _dbContext.Orders
                    .Include(order => order.Items)
                    .SingleOrDefaultAsync(order => order.Id == id.Value);
                if (data is null) throw new DomainException();
                _orders.Add(id, data);
                return RestoreOrderFrom(data);
            }

            public Task Save(Order order)
            {
                if (!_orders.TryGetValue(order.Id, out var orderData))
                {
                    orderData = new OrderData {Id = order.Id.Value};
                    _dbContext.Orders.Add(orderData);
                }
                foreach (var newEvent in order.NewEvents)
                {
                    switch (newEvent)
                    {
                        case Order.CreatedFromOffer createdFromOffer:
                            orderData.PriceAgreementType = nameof(Order.PriceAgreementType.Final);
                            orderData.PriceAgreementExpiresOn = null;
                            orderData.Items = CreateOrderItemsDataFrom(createdFromOffer.PriceConfirmations);
                            orderData.IsPlaced = true;
                            break;
                        case Order.ProductAmountAdded productAmountAdded:
                            orderData.Items.Add(new OrderItemData
                            {
                                ProductId = productAmountAdded.ProductId,
                                Amount = productAmountAdded.Amount,
                                AmountUnit = productAmountAdded.AmountUnit,
                                Price = null,
                                Currency = null
                            });
                            break;
                        case Order.PricesConfirmed pricesConfirmed:
                            orderData.PriceAgreementType = nameof(Order.PriceAgreementType.Temporary);
                            orderData.PriceAgreementExpiresOn = pricesConfirmed.PriceAgreementExpiresOn;
                            orderData.Items = CreateOrderItemsDataFrom(pricesConfirmed.PriceConfirmations);
                            break;
                        case Order.Placed _:
                            orderData.IsPlaced = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(newEvent), newEvent, null);
                    }
                }
                return Task.CompletedTask;
            }

            private static List<OrderItemData> CreateOrderItemsDataFrom(
                ImmutableArray<Order.PriceConfirmation> priceConfirmations) =>
                priceConfirmations
                    .Select(priceConfirmation => new OrderItemData
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