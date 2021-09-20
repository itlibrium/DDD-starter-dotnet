using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Integration.Payments
{
    public interface PaymentsModule
    {
        void AddPaymentRequestFor(OrderId orderId, Money amount);
    }
}