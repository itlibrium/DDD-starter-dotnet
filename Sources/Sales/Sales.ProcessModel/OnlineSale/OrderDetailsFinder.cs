using System;
using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.OnlineSale
{
    public interface OrderDetailsFinder
    {
        Task<OrderDetails> GetBy(Guid id);
    }
}