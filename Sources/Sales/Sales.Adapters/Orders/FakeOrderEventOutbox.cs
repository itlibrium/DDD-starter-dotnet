namespace MyCompany.ECommerce.Sales.Orders;

public class FakeOrderEventOutbox(FakeMessageBroker broker) : OrderEventsOutbox
{
    public void Add(OrderEvent orderEvent) => broker.Publish(orderEvent);
}