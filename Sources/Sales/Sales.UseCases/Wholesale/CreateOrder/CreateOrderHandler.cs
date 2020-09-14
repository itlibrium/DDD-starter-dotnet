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
        private readonly OrderEventsOutbox _eventsOutbox;

        public CreateOrderHandler(OrderRepository orders, OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<OrderCreated> Handle(CreateOrder command)
        {
            var clientId = CreateDomainModelFrom(command);
            var order = Order.New();
            await _orders.Save(order);
            var orderCreated = CreateEventFrom(order, clientId);
            _eventsOutbox.Add(orderCreated);
            return orderCreated;
        }

        private static ClientId CreateDomainModelFrom(CreateOrder command) => ClientId.From(command.ClientId);
        
        // TODO: add sales channel type
        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) => 
            new OrderCreated(order.Id.Value, clientId.Value);
    }
}