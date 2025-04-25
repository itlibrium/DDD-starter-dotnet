using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing;

public readonly struct GetOffer(Guid orderId, string currencyCode) : Command
{
    public Guid OrderId { get; } = orderId;
    public string CurrencyCode { get; } = currencyCode;
}