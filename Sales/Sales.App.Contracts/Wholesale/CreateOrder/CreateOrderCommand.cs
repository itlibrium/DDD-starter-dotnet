using System;

namespace MyCompany.Crm.Sales.Wholesale.CreateOrder
{
    public readonly struct CreateOrderCommand
    {
        public Guid ClientId { get; }

        public CreateOrderCommand(Guid clientId) => ClientId = clientId;
    }
}