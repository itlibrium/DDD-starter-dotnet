using System;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesale.OrderPricing
{
    public readonly struct GetOffer : Command
    {
        public Guid OrderId { get; }
        public string CurrencyCode { get; }

        public GetOffer(Guid orderId, string currencyCode)
        {
            OrderId = orderId;
            CurrencyCode = currencyCode;
        }
    }
}