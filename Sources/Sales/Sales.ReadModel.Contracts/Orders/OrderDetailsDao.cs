using System;
using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderDetailsDao
    {
        Task<AllOrderDetails> GetBy(Guid id);
    }
}