using System;
using System.Threading.Tasks;

namespace MyCompany.ECommerce.Sales.OnlineSale
{
    public interface OrderDetailsFinder
    {
        Task<OrderDetails> GetBy(Guid id);
    }
}