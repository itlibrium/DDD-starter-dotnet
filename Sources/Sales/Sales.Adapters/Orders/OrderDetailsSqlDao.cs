using System;
using System.Threading.Tasks;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.Orders
{
    // TODO: implementation for all persistence options used for OrderRepository
    [Dao]
    public class OrderDetailsSqlDao : OnlineSale.OrderDetailsFinder,
        Wholesale.OrderDetailsFinder
    {
        Task<OnlineSale.OrderDetails> OnlineSale.OrderDetailsFinder.GetBy(Guid id) =>
            throw new NotImplementedException();
        
        Task<AllOrderDetails> Wholesale.OrderDetailsFinder.GetBy(Guid id) =>
            throw new NotImplementedException();
    }
}