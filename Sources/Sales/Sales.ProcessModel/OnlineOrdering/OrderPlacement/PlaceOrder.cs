using System;
using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering.OrderPlacement
{
    [ProcessStepContract]
    public readonly struct PlaceOrder : Command
    {
        public Guid ClientId { get; }
        public string CurrencyCode { get; }
        public ImmutableArray<QuoteDto> Quotes { get; }
        public InvoicingDetails InvoicingDetails { get; }

        public PlaceOrder(Guid clientId, string currencyCode, ImmutableArray<QuoteDto> quotes, 
            InvoicingDetails invoicingDetails)
        {
            ClientId = clientId;
            CurrencyCode = currencyCode;
            Quotes = quotes;
            InvoicingDetails = invoicingDetails;
        }
    }
}