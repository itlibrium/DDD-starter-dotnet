using System;
using System.Threading.Tasks;

namespace MyCompany.ECommerce.Sales.OnlineOrdering
{
    public interface OrderDetailsFinder
    {
        Task<OrderDetails> GetBy(Guid id);
    }
}