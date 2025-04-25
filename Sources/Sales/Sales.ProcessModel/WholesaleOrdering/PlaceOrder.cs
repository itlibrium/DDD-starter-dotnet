using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public readonly struct PlaceOrder(Guid orderId) : Command
{
    public Guid OrderId { get; } = orderId;
}