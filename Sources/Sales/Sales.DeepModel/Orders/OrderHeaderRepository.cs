using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    [DddRepository]
    public interface OrderHeaderRepository
    {
        Task<(ClientId ClientId, TaxId TaxId)> GetBy(OrderId orderId);
    }
}