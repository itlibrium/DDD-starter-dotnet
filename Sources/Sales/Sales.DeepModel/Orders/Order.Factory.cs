using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Integrations.RiskManagement;
using MyCompany.ECommerce.Sales.Pricing;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    [DddFactory]
    public abstract class Factory
    {
        private readonly RiskManagement _riskManagement;
        
        protected Factory(RiskManagement riskManagement) => _riskManagement = riskManagement;

        public async Task<Order> NewWithMaxTotalCostFor(ClientId clientId)
        {
            var maxTotalCost = await _riskManagement.GetMaxOrderTotalCostFor(clientId);
            return NewWith(maxTotalCost);
        }
        
        public Order NewWith(Money maxTotalCost)
        {
            var id = OrderId.New();
            var data = CreateData(id, maxTotalCost);
            return new Order(data);
        }

        public Order ImmediatelyPlacedBasedOn(Offer offer)
        {
            var id = OrderId.New();
            var data = CreateData(id, offer.TotalPrice);
            var order = new Order(data);
            foreach (var quote in offer.Quotes)
            {
                var item = Item.For(quote.ProductAmount);
                item.ConfirmPrice(quote.Price);
                order._data.Add(item);
            }
            order._data.IsPlaced = true;
            return order;
        }

        protected abstract Data CreateData(OrderId id, Money maxTotalCost);
    }
}