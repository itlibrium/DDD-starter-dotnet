using System;
using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales
{
    // TODO: implementation for all persistence options used for OrderRepository
    [Stateless]
    public class OrderDetailsSqlDao : OrderDetailsDao
    {
        public Task<AllOrderDetails> GetBy(Guid id) => throw new NotImplementedException();
    }
}