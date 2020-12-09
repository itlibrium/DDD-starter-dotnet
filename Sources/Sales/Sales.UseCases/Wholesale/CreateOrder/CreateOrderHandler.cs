using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.SalesChannels;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.CreateOrder
{
    [DddAppService]
    public class CreateOrderHandler : CommandHandler<CreateOrder, OrderCreated>
    {
        private readonly OrderRepository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;

        public CreateOrderHandler(OrderRepository orders, SalesCrudOperations crudOperations, 
            OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<OrderCreated> Handle(CreateOrder command)
        {
            var clientId = CreateDomainModelFrom(command);
            var order = Order.New();
            var orderHeader = new OrderHeader {Id = order.Id.Value, ClientId = clientId.Value};
            await _orders.Save(order);
            await _crudOperations.Create(orderHeader);
            var orderCreated = CreateEventFrom(order, clientId);
            _eventsOutbox.Add(orderCreated);
            return orderCreated;
        }

        private static ClientId CreateDomainModelFrom(CreateOrder command) => ClientId.From(command.ClientId);

        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) =>
            new OrderCreated(order.Id.Value, clientId.Value, SalesChannel.Wholesales.ToCode());
    }
}