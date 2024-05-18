using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Payments.Requesting;

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