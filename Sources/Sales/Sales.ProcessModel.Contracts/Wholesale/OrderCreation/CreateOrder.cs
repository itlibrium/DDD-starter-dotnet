using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.OrderCreation
{
    public readonly struct CreateOrder : Command
    {
        public Guid ClientId { get; }

        public CreateOrder(Guid clientId) => ClientId = clientId;
    }
}