using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales
{
    public interface OrderEvent : DomainEvent
    {
        public Guid OrderId { get; }
    }
}