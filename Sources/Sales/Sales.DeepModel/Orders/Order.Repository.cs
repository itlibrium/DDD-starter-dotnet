using System.Threading.Tasks;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    [DddRepository]
    public interface Repository
    {
        Task<Order> GetBy(OrderId id);
        Task Save(Order order);
    }
}