using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderCreation
{
    public readonly struct CreateOrder : Command
    {
        public ClientId ClientId { get; }

        public CreateOrder(ClientId clientId) => ClientId = clientId;
    }
}