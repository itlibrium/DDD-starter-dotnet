using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.Wholesale.OrderPricing;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Wholesale
{
    [ApiController]
    [Route("rest/wholesale/orders/{id}/current-offer")]
    [ApiVersion("1")]
    public class WholesaleOrdersCurrentOfferController : ControllerBase
    {
        private readonly CommandHandler<GetOffer, OfferCalculated> _getOfferHandler;

        public WholesaleOrdersCurrentOfferController(CommandHandler<GetOffer, OfferCalculated> getOfferHandler) =>
            _getOfferHandler = getOfferHandler;

        [HttpGet]
        public async Task<IEnumerable<QuoteDto>> GetOffer(Guid id, string currencyCode)
        {
            var offerCalculated = await _getOfferHandler.Handle(new GetOffer(id, currencyCode));
            return offerCalculated.Quotes;
        }
    }
}