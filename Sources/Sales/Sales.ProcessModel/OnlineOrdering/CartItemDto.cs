namespace MyCompany.ECommerce.Sales.OnlineOrdering;

public readonly struct CartItemDto(Guid productId, int amount)
{
    public Guid ProductId { get; } = productId;
    public int Amount { get; } = amount;
}