using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Wholesale.CreateOrder
{
    public class CreateOrderHandler
    {
        private readonly OrderRepository _orders;

        public CreateOrderHandler(OrderRepository orders) => _orders = orders;

        public async Task<OrderCreated> Handle(CreateOrderCommand command)
        {
            var clientId = CreateDomainModelFrom(command);
            var order = Order.New();
            await _orders.Save(order);
            return CreateEventFrom(order, clientId);
        }

        private static ClientId CreateDomainModelFrom(CreateOrderCommand command) => ClientId.From(command.ClientId);
        
        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) => 
            new OrderCreated(order.Id.Value, clientId.Value);
    }
}