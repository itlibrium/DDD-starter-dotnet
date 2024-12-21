using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement;

public readonly struct PlaceOrder(Guid orderId) : Command
{
    public Guid OrderId { get; } = orderId;
}