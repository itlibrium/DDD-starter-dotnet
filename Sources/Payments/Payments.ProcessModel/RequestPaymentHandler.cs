using System.Threading.Tasks;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Payments
{
    public class RequestPaymentHandler : CommandHandler<RequestPayment>
    {
        public Task Handle(RequestPayment command)
        {
            throw new System.NotImplementedException();
        }
    }
}