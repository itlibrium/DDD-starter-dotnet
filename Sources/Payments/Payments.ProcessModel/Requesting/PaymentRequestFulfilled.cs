using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Payments.Requesting;

public class PaymentRequestFulfilled(Guid requestId, DateTime fulfilledOn) : DomainEvent
{
    public Guid RequestId { get; } = requestId;
    public DateTime FulfilledOn { get; } = fulfilledOn;
}