namespace MyCompany.ECommerce.Sales.Orders;

// TODO: implementation for all persistence options used for OrderRepository
public class OrderDetailsSqlRepository : OnlineOrdering.OrderDetailsFinder,
    WholesaleOrdering.OrderDetailsFinder
{
    Task<OnlineOrdering.OrderDetails> OnlineOrdering.OrderDetailsFinder.GetBy(Guid id) =>
        throw new NotImplementedException();
        
    Task<AllOrderDetails> WholesaleOrdering.OrderDetailsFinder.GetBy(Guid id) =>
        throw new NotImplementedException();
}