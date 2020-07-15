using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderHeaderRepository
    {
        Task<(ClientId ClientId, TaxId TaxId)> GetBy(OrderId orderId);
    }
}