using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing
{
    [ProcessStepContract]
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