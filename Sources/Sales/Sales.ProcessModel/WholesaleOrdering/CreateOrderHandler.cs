using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[UsedImplicitly]
public class CreateOrderHandler(
    Order.Repository orders,
    SalesCrudOperations crudOperations,
    OrderEventsOutbox eventsOutbox)
    : CommandHandler<CreateOrder, OrderCreated>
{
    private readonly Order.Factory _orderFactory;

    [Actor(Actors.WholesaleClient)]
    public async Task<OrderCreated> Handle(CreateOrder command)
    {
            var clientId = command.ClientId;
            var order = await _orderFactory.NewWithMaxTotalCostFor(clientId);
            var orderHeader = new OrderHeader {Id = order.Id.Value, ClientId = clientId.Value};
            await orders.Save(order);
            await crudOperations.Create(orderHeader);
            var orderCreated = CreateEventFrom(order, clientId);
            eventsOutbox.Add(orderCreated);
            return orderCreated;
        }

    private static OrderCreated CreateEventFrom(Order order, ClientId clientId) =>
        new(order.Id.Value, clientId.Value, SalesChannel.Wholesale.ToCode());
}