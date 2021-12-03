using System;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales
{
    public interface OrderEvent : DomainEvent
    {
        public Guid OrderId { get; }
    }
}