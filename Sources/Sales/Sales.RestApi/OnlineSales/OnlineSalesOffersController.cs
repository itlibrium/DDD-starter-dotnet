using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.OnlineSales.PriceCart;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.OnlineSales
{
    [ApiController]
    [Route("rest/online-sales/offer-request")]
    [ApiVersion("1")]
    public class OnlineSalesOffersController : ControllerBase
    {
        private readonly CommandHandler<PriceCart.PriceCart, CartPriced> _priceCartHandler;

        public OnlineSalesOffersController(CommandHandler<PriceCart.PriceCart, CartPriced> priceCartHandler) =>
            _priceCartHandler = priceCartHandler;

        [HttpPost]
        public async Task<CartPriced> PriceCart(PriceCart.PriceCart priceCart) =>
            await _priceCartHandler.Handle(priceCart);
    }
}