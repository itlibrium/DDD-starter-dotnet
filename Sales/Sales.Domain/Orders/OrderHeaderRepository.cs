using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Orders
{
    public interface OrderHeaderRepository
    {
        Task<OrderHeader> GetBy(OrderId orderId);
    }
}