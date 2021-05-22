using System;

namespace MyCompany.Crm.Sales.Wholesale.ProductPricing
{
    public class QuickQuoteCalculated
    {
        public Guid ClientId { get; }
        public QuoteDto Quote { get; }

        public QuickQuoteCalculated(Guid clientId, QuoteDto quote)
        {
            ClientId = clientId;
            Quote = quote;
        }
    }
}