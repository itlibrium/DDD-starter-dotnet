using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Integration.ProductsDelivery
{
    public interface ProductsDeliveryModule
    {
        void AddDeliveryRequestFor(AllOrderDetails orderDetails);
    }
}