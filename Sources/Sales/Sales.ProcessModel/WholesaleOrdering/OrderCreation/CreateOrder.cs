using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderCreation
{
    [ProcessStepContract]
    public readonly struct CreateOrder : Command
    {
        public ClientId ClientId { get; }

        public CreateOrder(ClientId clientId) => ClientId = clientId;
    }
}