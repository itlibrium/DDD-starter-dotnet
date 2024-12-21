using MyCompany.ECommerce.Sales.Orders;

namespace MyCompany.ECommerce.Sales.Integrations.ProductsDelivery;

public interface ProductsDeliveryModule
{
    void AddDeliveryRequestFor(AllOrderDetails orderDetails);
}