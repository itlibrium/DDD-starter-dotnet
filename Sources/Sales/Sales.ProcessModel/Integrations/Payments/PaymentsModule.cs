using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Orders;

namespace MyCompany.ECommerce.Sales.Integrations.Payments;

public interface PaymentsModule
{
    void AddPaymentRequestFor(OrderId orderId, Money amount);
}