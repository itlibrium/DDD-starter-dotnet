using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class OrderSqlRepository
    {
        private class TablesFromSnapshot : OrderRepository
        {
            private readonly Dictionary<OrderId, OrderData> _orders = new Dictionary<OrderId, OrderData>();
            private readonly SalesDbContext _dbContext;

            public TablesFromSnapshot(SalesDbContext dbContext) => _dbContext = dbContext;

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
                if (!_orders.TryGetValue(order.Id, out var data))
                {
                    data = new OrderData {Id = order.Id.Value};
                    _dbContext.Orders.Add(data);
                }
                var snapshot = order.GetSnapshot();
                data.Items = snapshot.Items
                    .Select(item => new OrderItemData
                    {
                        ProductId = item.ProductId,
                        Amount = item.Amount,
                        AmountUnit = item.AmountUnit,
                        Price = item.Price,
                        Currency = item.Currency
                    })
                    .ToList();
                data.PriceAgreementType = snapshot.PriceAgreementType;
                data.PriceAgreementExpiresOn = snapshot.PriceAgreementExpiresOn;
                data.IsPlaced = snapshot.IsPlaced;
                return Task.CompletedTask;
            }
        }
    }
}