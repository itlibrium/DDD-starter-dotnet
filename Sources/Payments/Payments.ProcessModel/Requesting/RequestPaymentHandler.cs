using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Payments.Requesting;

[UsedImplicitly]
[ProcessStep(nameof(RequestPayment), Process = PaymentProcess.Name)]
public class RequestPaymentHandler : CommandHandler<RequestPayment>
{
    public Task Handle(RequestPayment command)
    {
        throw new System.NotImplementedException();
    }
}