using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.OnlineOrdering.CartPricing;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[ApiController]
[Route("rest/online-ordering/offer-request")]
[ApiVersion("1")]
public class OffersController : ControllerBase
{
    private readonly CommandHandler<PriceCart, CartPriced> _priceCartHandler;

    public OffersController(CommandHandler<PriceCart, CartPriced> priceCartHandler) =>
        _priceCartHandler = priceCartHandler;

    [HttpPost]
    public async Task<CartPriced> PriceCart(PriceCart priceCart) =>
        await _priceCartHandler.Handle(priceCart);
}