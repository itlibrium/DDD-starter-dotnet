using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderEvent : DomainEvent
    {
        public Guid OrderId { get; }
    }
}