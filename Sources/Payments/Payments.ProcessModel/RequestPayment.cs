using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Payments
{
    public readonly struct RequestPayment : Command
    {
        public Guid RequestId { get; }
        public Guid ClientId { get; }
        public decimal Amount { get; }
        public string CurrencyCode { get; }

        public RequestPayment(Guid requestId, Guid clientId, decimal amount, string currencyCode)
        {
            RequestId = requestId;
            ClientId = clientId;
            Amount = amount;
            CurrencyCode = currencyCode;
        }
    }

    public class PaymentRequestFulfilled : DomainEvent
    {
        public Guid RequestId { get; }
        public DateTime FulfilledOn { get; }

        public PaymentRequestFulfilled(Guid requestId, DateTime fulfilledOn)
        {
            RequestId = requestId;
            FulfilledOn = fulfilledOn;
        }
    }
}