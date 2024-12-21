using MyCompany.ECommerce.Sales.Orders;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[DddRepository]
public interface OrderDetailsFinder
{
    Task<AllOrderDetails> GetBy(Guid id);
}