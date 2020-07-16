using System;

namespace MyCompany.Crm.Sales.OnlineSales
{
    public readonly struct CartItemDto
    {
        public Guid ProductId { get; }
        public int Amount { get; }

        public CartItemDto(Guid productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }
    }
}