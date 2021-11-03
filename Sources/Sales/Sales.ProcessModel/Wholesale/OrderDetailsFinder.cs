using System;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Wholesale
{
    public interface OrderDetailsFinder
    {
        Task<AllOrderDetails> GetBy(Guid id);
    }
}