using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.Wholesale.ProductPricing;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Wholesale
{
    [ApiController]
    [Route("rest/wholesale/quotes")]
    [ApiVersion("1")]
    public class WholesaleQuotesController : ControllerBase
    {
        private readonly CommandHandler<GetQuickQuote, QuickQuoteCalculated> _getQuickQuoteHandler;

        public WholesaleQuotesController(CommandHandler<GetQuickQuote, QuickQuoteCalculated> getQuickQuoteHandler) =>
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