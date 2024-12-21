namespace MyCompany.ECommerce.Sales;

public interface OrderEventsOutbox
{
    public void Add(OrderEvent orderEvent);
}