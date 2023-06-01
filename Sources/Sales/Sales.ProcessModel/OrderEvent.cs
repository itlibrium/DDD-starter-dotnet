using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales
{
    public interface OrderEvent : DomainEvent
    {
        public Guid OrderId { get; }
    }
}