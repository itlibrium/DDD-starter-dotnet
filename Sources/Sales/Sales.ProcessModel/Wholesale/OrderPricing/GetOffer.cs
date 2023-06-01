using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Wholesale.OrderPricing
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