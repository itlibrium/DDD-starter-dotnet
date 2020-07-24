using System;

namespace MyCompany.Crm.Sales
{
    public interface OrderEvent
    {
        public Guid OrderId { get; }
    }
}