using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Payments
{
    public class RequestPaymentHandler : CommandHandler<RequestPayment>
    {
        public Task Handle(RequestPayment command)
        {
            throw new System.NotImplementedException();
        }
    }
}