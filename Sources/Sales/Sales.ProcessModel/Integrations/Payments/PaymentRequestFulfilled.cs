using System;

namespace MyCompany.ECommerce.Sales.Integrations.Payments
{
    public class PaymentRequestFulfilled : OrderEvent
    {
        public Guid OrderId { get; }
    }
}