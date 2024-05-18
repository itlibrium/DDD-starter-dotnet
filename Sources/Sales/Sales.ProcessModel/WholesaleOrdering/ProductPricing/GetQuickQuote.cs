using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.ProductPricing
{
    public readonly struct GetQuickQuote : Command
    {
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }
        public string CurrencyCode { get; }

        public GetQuickQuote(Guid clientId, Guid productId, int amount, string unitCode, string currencyCode)
        {
            ClientId = clientId;
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
            CurrencyCode = currencyCode;
        }
    }
}