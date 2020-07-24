namespace MyCompany.Crm.Sales
{
    public interface OrderEventsOutbox
    {
        public void Add(OrderEvent orderEvent);
    }
}