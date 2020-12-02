using System;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderEvent
    {
        public Guid OrderId { get; }
    }
}