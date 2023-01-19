using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders;

public partial class Order
{
    [DddRepository]
    public interface Repository
    {
        Task<Order> GetBy(OrderId id);
        Task Save(Order order);
    }
}