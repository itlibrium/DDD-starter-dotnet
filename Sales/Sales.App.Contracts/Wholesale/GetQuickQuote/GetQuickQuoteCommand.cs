using System;

namespace MyCompany.Crm.Sales.Wholesale.GetQuickQuote
{
    public readonly struct GetQuickQuoteCommand
    {
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public int Amount { get; }
        public string UnitCode { get; }
        public string CurrencyCode { get; }

        public GetQuickQuoteCommand(Guid clientId, Guid productId, int amount, string unitCode, string currencyCode)
        {
            ClientId = clientId;
            ProductId = productId;
            Amount = amount;
            UnitCode = unitCode;
            CurrencyCode = currencyCode;
        }
    }
}