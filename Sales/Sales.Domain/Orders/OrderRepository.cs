using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderRepository
    {
        Task<Order> GetBy(OrderId id);
        Task Save(Order order);
    }
}