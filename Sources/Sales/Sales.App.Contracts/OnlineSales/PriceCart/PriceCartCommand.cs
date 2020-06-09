using System;
using System.Collections.Immutable;

namespace MyCompany.Crm.Sales.OnlineSales.PriceCart
{
    public readonly struct PriceCartCommand
    {
        public Guid ClientId { get; }   
        public string Currency { get; }
        public ImmutableArray<CartItemDto> CartItems { get; }

        public PriceCartCommand(Guid clientId, string currency, ImmutableArray<CartItemDto> cartItems)
        {
            ClientId = clientId;
            Currency = currency;
            CartItems = cartItems;
        }
    }
}