using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Time;

namespace MyCompany.Crm.Sales.Wholesale.PlaceOrder
{
    public class PlaceOrderHandler
    {
        private readonly OrderRepository _orders;
        private readonly Clock _clock;

        public PlaceOrderHandler(OrderRepository orders, Clock clock)
        {
            _orders = orders;
            _clock = clock;
        }

        public async Task<OrderPlaced> Handle(PlaceOrder command)
        {
            var orderId = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            order.Place(_clock.Now);
            await _orders.Save(order);
            return CreateEventFrom(order);
        }
        
        private static OrderId CreateDomainModelFrom(PlaceOrder command) => OrderId.From(command.OrderId);
        
        private static OrderPlaced CreateEventFrom(Order order) => new OrderPlaced(order.Id.Value);
    }
}