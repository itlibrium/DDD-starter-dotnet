using System;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Time;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderPlacement
{
    [DddAppService]
    public class PlaceOrderHandler : CommandHandler<PlaceOrder, OrderPlaced>
    {
        private readonly OrderRepository _orders;
        private readonly SalesCrudOperations _crudOperations;
        private readonly Clock _clock;
        private readonly OrderEventsOutbox _eventsOutbox;

        public PlaceOrderHandler(OrderRepository orders, SalesCrudOperations crudOperations, Clock clock, 
            OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _crudOperations = crudOperations;
            _clock = clock;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<OrderPlaced> Handle(PlaceOrder command)
        {
            var orderId = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            var now = _clock.Now;
            order.Place(now);
            await _orders.Save(order);
            var orderPlaced = await CreateEventFrom(order, now);
            _eventsOutbox.Add(orderPlaced);
            return orderPlaced;
        }
        
        private static OrderId CreateDomainModelFrom(PlaceOrder command) => OrderId.From(command.OrderId);

        private async Task<OrderPlaced> CreateEventFrom(Order order, DateTime placedOn)
        {
            var orderHeader = await _crudOperations.Read<OrderHeader>(order.Id.Value);
            return new OrderPlaced(order.Id.Value, orderHeader.ClientId, placedOn);
        }
    }
}