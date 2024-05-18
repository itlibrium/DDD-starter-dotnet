namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

public readonly struct QuoteDto(Guid productId, int amount, string unitCode, decimal price, string currencyCode)
{
    public Guid ProductId { get; } = productId;
    public int Amount { get; } = amount;
    public string UnitCode { get; } = unitCode;
    public decimal Price { get; } = price;
    public string CurrencyCode { get; } = currencyCode;
}