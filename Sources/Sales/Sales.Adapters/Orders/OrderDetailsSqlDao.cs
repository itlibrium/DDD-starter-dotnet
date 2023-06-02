using System;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.OnlineOrdering;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.Orders
{
    // TODO: implementation for all persistence options used for OrderRepository
    [Dao]
    public class OrderDetailsSqlDao : OrderDetailsFinder,
        WholesaleOrdering.OrderDetailsFinder
    {
        Task<OrderDetails> OrderDetailsFinder.GetBy(Guid id) =>
            throw new NotImplementedException();
        
        Task<AllOrderDetails> WholesaleOrdering.OrderDetailsFinder.GetBy(Guid id) =>
            throw new NotImplementedException();
    }
}