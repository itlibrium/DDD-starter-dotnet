using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.ProductPricing;

public readonly struct GetQuickQuote(Guid clientId, Guid productId, int amount, string unitCode, string currencyCode)
    : Command
{
    public Guid ClientId { get; } = clientId;
    public Guid ProductId { get; } = productId;
    public int Amount { get; } = amount;
    public string UnitCode { get; } = unitCode;
    public string CurrencyCode { get; } = currencyCode;
}