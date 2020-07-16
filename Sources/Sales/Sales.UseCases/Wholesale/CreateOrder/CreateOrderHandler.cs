using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.CreateOrder
{
    [Stateless]
    [DddAppService]
    public class CreateOrderHandler : CommandHandler<CreateOrder, OrderCreated>
    {
        private readonly OrderRepository _orders;

        public CreateOrderHandler(OrderRepository orders) => _orders = orders;

        public async Task<OrderCreated> Handle(CreateOrder command)
        {
            var clientId = CreateDomainModelFrom(command);
            var order = Order.New();
            await _orders.Save(order);
            return CreateEventFrom(order, clientId);
        }

        private static ClientId CreateDomainModelFrom(CreateOrder command) => ClientId.From(command.ClientId);
        
        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) => 
            new OrderCreated(order.Id.Value, clientId.Value);
    }
}