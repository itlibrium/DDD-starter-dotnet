using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Wholesale;
using MyCompany.Crm.Sales.Wholesale.GetOffer;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders/{id}/current-offer")]
    [ApiVersion("1")]
    public class WholesalesOrdersCurrentOfferController : ControllerBase
    {
        private readonly CommandHandler<GetOffer, OfferCalculated> _getOfferHandler;

        public WholesalesOrdersCurrentOfferController(CommandHandler<GetOffer, OfferCalculated> getOfferHandler) =>
            _getOfferHandler = getOfferHandler;

        [HttpGet]
        public async Task<IEnumerable<QuoteDto>> GetOffer(Guid id, string currencyCode)
        {
            var offerCalculated = await _getOfferHandler.Handle(new GetOffer(id, currencyCode));
            return offerCalculated.Quotes;
        }
    }
}