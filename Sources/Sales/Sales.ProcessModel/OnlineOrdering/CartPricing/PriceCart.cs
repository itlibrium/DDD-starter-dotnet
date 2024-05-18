using System;
using System.Collections.Immutable;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.CartPricing
{
    public readonly struct PriceCart : Command
    {
        public Guid ClientId { get; }   
        public string Currency { get; }
        public ImmutableArray<CartItemDto> CartItems { get; }

        public PriceCart(Guid clientId, string currency, ImmutableArray<CartItemDto> cartItems)
        {
            ClientId = clientId;
            Currency = currency;
            CartItems = cartItems;
        }
    }
}