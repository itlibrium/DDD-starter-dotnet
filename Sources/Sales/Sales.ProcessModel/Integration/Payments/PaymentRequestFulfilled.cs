using System;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Integration.Payments
{
    public class PaymentRequestFulfilled : OrderEvent
    {
        public Guid OrderId { get; }
    }
}