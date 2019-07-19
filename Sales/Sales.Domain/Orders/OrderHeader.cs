using MyCompany.Crm.Sales.Clients;

namespace MyCompany.Crm.Sales.Orders
{
    public readonly struct OrderHeader
    {
        public OrderId OrderId { get; }
        public ClientId ClientId { get; }
        // and many more

        public OrderHeader(OrderId orderId, ClientId clientId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}