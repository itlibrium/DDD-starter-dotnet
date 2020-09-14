using System;
using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderReadModelDao
    {
        Task<OrderReadModel> GetBy(Guid id);
    }
}