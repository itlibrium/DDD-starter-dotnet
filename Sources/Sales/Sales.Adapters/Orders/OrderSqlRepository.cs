namespace MyCompany.ECommerce.Sales.Orders;

public static partial class OrderSqlRepository
{
    private const string SameAggregateRestoredMoreThanOnce =
        "Same aggregate is restored from the repository more than once in a single business transaction";

    private const string SaveOfUnknownAggregate =
        $"Attempt to save {nameof(Order)} that wasn't created nor get with {nameof(OrderSqlRepository)}";
}