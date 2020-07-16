using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    [Stateless]
    [DddRepository]
    public class OrderHeaderSqlRepository : OrderHeaderRepository
    {
        public Task<(ClientId ClientId, TaxId TaxId)> GetBy(OrderId orderId) => 
            throw new System.NotImplementedException();
    }
}