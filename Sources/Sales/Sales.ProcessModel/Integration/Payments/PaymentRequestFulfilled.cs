using System;

namespace MyCompany.Crm.Sales.Integration.Payments
{
    public class PaymentRequestFulfilled : OrderEvent
    {
        public Guid OrderId { get; }
    }
}