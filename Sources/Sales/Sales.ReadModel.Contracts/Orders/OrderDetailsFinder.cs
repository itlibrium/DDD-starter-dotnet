using System;
using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderDetailsFinder
    {
        Task<AllOrderDetails> GetBy(Guid id);
    }
}