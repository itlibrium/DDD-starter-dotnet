using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Wholesale;
using MyCompany.Crm.Sales.Wholesale.ProductPricing;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/quotes")]
    [ApiVersion("1")]
    public class WholesalesQuotesController : ControllerBase
    {
        private readonly CommandHandler<GetQuickQuote, QuickQuoteCalculated> _getQuickQuoteHandler;

        public WholesalesQuotesController(CommandHandler<GetQuickQuote, QuickQuoteCalculated> getQuickQuoteHandler) =>
            _getQuickQuoteHandler = getQuickQuoteHandler;

        [HttpGet]
        public async Task<QuoteDto> GetQuote(Guid clientId, Guid productId, int amount, string unitCode,
            string currencyCode)
        {
            var quoteCalculated = await _getQuickQuoteHandler.Handle(
                new GetQuickQuote(clientId, productId, amount, unitCode, currencyCode));
            return quoteCalculated.Quote;
        }
    }
}