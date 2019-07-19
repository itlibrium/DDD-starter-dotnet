using System;

namespace MyCompany.Crm.Sales.Wholesale.GetOffer
{
    public readonly struct GetOfferCommand
    {
        public Guid OrderId { get; }
        public string CurrencyCode { get; }

        public GetOfferCommand(Guid orderId, string currencyCode)
        {
            OrderId = orderId;
            CurrencyCode = currencyCode;
        }
    }
}