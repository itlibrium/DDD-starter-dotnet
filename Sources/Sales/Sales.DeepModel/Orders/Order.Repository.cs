using System.Threading.Tasks;
using P3Model.Annotations.Domain.StaticModel.DDD;

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