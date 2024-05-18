using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[DddRepository]
public interface OrderDetailsFinder
{
    Task<OrderDetails> GetBy(Guid id);
}