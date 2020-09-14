using System;
using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.Orders
{
    [Stateless]
    public class OrderReadModelSqlDao : OrderReadModelDao
    {
        public Task<OrderReadModel> GetBy(Guid id) => throw new NotImplementedException();
    }
}