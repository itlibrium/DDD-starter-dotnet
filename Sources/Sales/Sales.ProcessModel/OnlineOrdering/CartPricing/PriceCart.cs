using System.Collections.Immutable;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.CartPricing;

public readonly struct PriceCart(Guid clientId, string currency, ImmutableArray<CartItemDto> cartItems)
    : Command
{
    public Guid ClientId { get; } = clientId;
    public string Currency { get; } = currency;
    public ImmutableArray<CartItemDto> CartItems { get; } = cartItems;
}