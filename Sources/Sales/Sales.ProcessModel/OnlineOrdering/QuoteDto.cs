using System;

namespace MyCompany.ECommerce.Sales.OnlineOrdering
{
    public readonly struct QuoteDto
    {
        public Guid ProductId { get; }
        public int Amount { get; }
        public decimal Price { get; }
        public string CurrencyCode { get; } 

        public QuoteDto(Guid productId, int amount, decimal price, string currencyCode)
        {
            ProductId = productId;
            Amount = amount;
            Price = price;
            CurrencyCode = currencyCode;
        }
    }
}