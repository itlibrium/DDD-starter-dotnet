using System;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering
{
    public readonly struct QuoteDto
    {
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }
        public decimal Price { get; }
        public string CurrencyCode { get; }

        public QuoteDto(Guid productId, int amount, string unitCode, decimal price, string currencyCode)
        {
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
            Price = price;
            CurrencyCode = currencyCode;
        }
    }
}