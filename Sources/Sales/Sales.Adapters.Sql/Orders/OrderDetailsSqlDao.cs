using System;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.Orders
{
    // TODO: implementation for all persistence options used for OrderRepository
    [Stateless]
    public class OrderDetailsSqlDao : OrderDetailsFinder
    {
        public Task<AllOrderDetails> GetBy(Guid id) => throw new NotImplementedException();
    }
}