using System;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Orders;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering
{
    public interface OrderDetailsFinder
    {
        Task<AllOrderDetails> GetBy(Guid id);
    }
}