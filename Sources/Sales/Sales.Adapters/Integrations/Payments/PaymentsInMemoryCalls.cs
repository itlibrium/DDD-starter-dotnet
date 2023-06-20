using MyCompany.ECommerce.Payments.Requesting;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Integrations.Payments
{
    public class PaymentsInMemoryCalls : PaymentsModule
    {
        private readonly CommandHandler<RequestPayment> _handler;
        
        public void AddPaymentRequestFor(OrderId orderId, Money amount)
        {
            // handler.Handle(new RequestPayment)
            throw new System.NotImplementedException();
        }
    }

    public class PaymentsIHttpCalls : PaymentsModule
    {
        // HttpClient
        public void AddPaymentRequestFor(OrderId orderId, Money amount)
        {
            //HttpClient.Post(...)
            throw new System.NotImplementedException();
        }
    }
}