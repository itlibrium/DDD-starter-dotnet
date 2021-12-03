using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.OnlineSale.CartPricing;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.OnlineSales
{
    [ApiController]
    [Route("rest/online-sales/offer-request")]
    [ApiVersion("1")]
    public class OnlineSalesOffersController : ControllerBase
    {
        private readonly CommandHandler<PriceCart, CartPriced> _priceCartHandler;

        public OnlineSalesOffersController(CommandHandler<PriceCart, CartPriced> priceCartHandler) =>
            _priceCartHandler = priceCartHandler;

        [HttpPost]
        public async Task<CartPriced> PriceCart(PriceCart priceCart) =>
            await _priceCartHandler.Handle(priceCart);
    }
}