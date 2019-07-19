using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Wholesale.PlaceOrder
{
    public class PlaceOrderHandler
    {
        private readonly OrderRepository _orders;
        
        public async Task<OrderPlaced> Handle(PlaceOrderCommand command)
        {
            var orderId = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            order.Place();
            await _orders.Save(order);
            return CreateEventFrom(order);
        }
        
        private static OrderId CreateDomainModelFrom(PlaceOrderCommand command) => OrderId.From(command.OrderId);
        
        private static OrderPlaced CreateEventFrom(Order order) => new OrderPlaced(order.Id.Value);
    }
}