using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation;

public readonly struct CreateOrder(ClientId clientId) : Command
{
    public ClientId ClientId { get; } = clientId;
}