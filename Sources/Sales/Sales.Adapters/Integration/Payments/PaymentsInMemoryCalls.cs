using MyCompany.Crm.Payments;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Integration.Payments
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