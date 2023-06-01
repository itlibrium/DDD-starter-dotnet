using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.OnlineSale.CartPricing;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.OnlineSale
{
    [ApiController]
    [Route("rest/online-sales/offer-request")]
    [ApiVersion("1")]
    public class OnlineSaleOffersController : ControllerBase
    {
        private readonly CommandHandler<PriceCart, CartPriced> _priceCartHandler;

        public OnlineSaleOffersController(CommandHandler<PriceCart, CartPriced> priceCartHandler) =>
            _priceCartHandler = priceCartHandler;

        [HttpPost]
        public async Task<CartPriced> PriceCart(PriceCart priceCart) =>
            await _priceCartHandler.Handle(priceCart);
    }
}