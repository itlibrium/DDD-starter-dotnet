using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation
{
    [UsedImplicitly]
    public class CreateOrderHandler : CommandHandler<CreateOrder, OrderCreated>
    {
        private readonly Order.Repository _orders;
        private readonly Order.Factory _orderFactory;
        private readonly SalesCrudOperations _crudOperations;
        private readonly OrderEventsOutbox _eventsOutbox;

        public CreateOrderHandler(Order.Repository orders, SalesCrudOperations crudOperations, 
            OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _eventsOutbox = eventsOutbox;
        }

        [UseCase(nameof(CreateOrder), Process = WholesaleOrderingProcess.Name)]
        [Actor(Actors.WholesaleClient)]
        public async Task<OrderCreated> Handle(CreateOrder command)
        {
            var clientId = command.ClientId;
            var order = await _orderFactory.NewWithMaxTotalCostFor(clientId);
            var orderHeader = new OrderHeader {Id = order.Id.Value, ClientId = clientId.Value};
            await _orders.Save(order);
            await _crudOperations.Create(orderHeader);
            var orderCreated = CreateEventFrom(order, clientId);
            _eventsOutbox.Add(orderCreated);
            return orderCreated;
        }

        private static OrderCreated CreateEventFrom(Order order, ClientId clientId) =>
            new(order.Id.Value, clientId.Value, SalesChannel.Wholesale.ToCode());
    }
}