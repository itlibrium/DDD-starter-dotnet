using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation
{
    public readonly struct CreateOrder : Command
    {
        public ClientId ClientId { get; }

        public CreateOrder(ClientId clientId) => ClientId = clientId;
    }
}