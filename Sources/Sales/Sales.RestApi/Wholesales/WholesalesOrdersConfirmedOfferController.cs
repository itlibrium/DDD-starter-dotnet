using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Wholesale;
using MyCompany.Crm.Sales.Wholesale.ConfirmOffer;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders/{id}/confirmed-offer")]
    [ApiVersion("1")]
    public class WholesalesOrdersConfirmedOfferController : ControllerBase
    {
        private readonly CommandHandler<ConfirmOffer, OfferConfirmed> _confirmOfferHandler;

        public WholesalesOrdersConfirmedOfferController(
            CommandHandler<ConfirmOffer, OfferConfirmed> confirmOfferHandler) =>
            _confirmOfferHandler = confirmOfferHandler;

        [HttpPut]
        public async Task<NoContentResult> ConfirmOffer(Guid id, ConfirmedOfferDto confirmedOffer)
        {
            await _confirmOfferHandler.Handle(
                new ConfirmOffer(id, confirmedOffer.CurrencyCode, confirmedOffer.Quotes.ToImmutableArray()));
            // TODO: change to SeeOther
            return NoContent();
        }

        [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
        public class ConfirmedOfferDto
        {
            [Required]
            public string CurrencyCode { get; set; }

            [Required]
            public List<QuoteDto> Quotes { get; set; }
        }
    }
}