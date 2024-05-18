using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderModification;

public readonly struct AddToOrder(Guid orderId, Guid productId, int amount, string unitCode)
    : Command
{
    public Guid OrderId { get; } = orderId;
    public Guid ProductId { get; } = productId;
    public int Amount { get; } = amount;
    public string UnitCode { get; } = unitCode;
}