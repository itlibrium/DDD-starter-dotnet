namespace MyCompany.Crm.Sales.Orders
{
    public class FakeOrderEventOutbox : OrderEventsOutbox
    {
        private readonly FakeMessageBroker _broker;
        
        public FakeOrderEventOutbox(FakeMessageBroker broker) => _broker = broker;

        public void Add(OrderEvent orderEvent) => _broker.Publish(orderEvent);
    }
}