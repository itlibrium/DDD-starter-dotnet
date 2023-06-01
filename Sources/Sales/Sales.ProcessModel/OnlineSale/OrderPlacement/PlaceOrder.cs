using System;
using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.OnlineSale.OrderPlacement
{
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