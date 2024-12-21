using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPricing;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[ApiController]
[Route("rest/wholesale-ordering/orders/{id}/current-offer")]
[ApiVersion("1")]
public class OrdersCurrentOfferController : ControllerBase
{
    private readonly CommandHandler<GetOffer, OfferCalculated> _getOfferHandler;

    public OrdersCurrentOfferController(CommandHandler<GetOffer, OfferCalculated> getOfferHandler) =>
        _getOfferHandler = getOfferHandler;

    [HttpGet]
    public async Task<IEnumerable<QuoteDto>> GetOffer(Guid id, string currencyCode)
    {
        var offerCalculated = await _getOfferHandler.Handle(new GetOffer(id, currencyCode));
        return offerCalculated.Quotes;
    }
}