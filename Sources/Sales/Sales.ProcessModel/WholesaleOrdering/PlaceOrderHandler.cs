using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Time;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[UsedImplicitly]
public class PlaceOrderHandler(
    Order.Repository orders,
    SalesCrudOperations crudOperations,
    Clock clock,
    OrderEventsOutbox eventsOutbox)
    : CommandHandler<PlaceOrder, OrderPlaced>
{
    [Actor(Actors.WholesaleClient)]
    public async Task<OrderPlaced> Handle(PlaceOrder command)
    {
            var orderId = CreateDomainModelFrom(command);
            var order = await orders.GetBy(orderId);
            var now = clock.Now;
            order.Place(now);
            await orders.Save(order);
            var orderPlaced = await CreateEventFrom(order, now);
            eventsOutbox.Add(orderPlaced);
            return orderPlaced;
        }
        
    private static OrderId CreateDomainModelFrom(PlaceOrder command) => OrderId.From(command.OrderId);

    private async Task<OrderPlaced> CreateEventFrom(Order order, DateTime placedOn)
    {
            var orderHeader = await crudOperations.Read<OrderHeader>(order.Id.Value);
            return new OrderPlaced(order.Id.Value, orderHeader.ClientId, placedOn);
        }
}