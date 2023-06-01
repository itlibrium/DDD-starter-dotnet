using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.Wholesale.OrderPlacement;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Wholesale
{
    [ApiController]
    [Route("rest/wholesale/orders/{id}/placement")]
    [ApiVersion("1")]
    public class WholesaleOrdersPlacementController : ControllerBase
    {
        private readonly CommandHandler<PlaceOrder, OrderPlaced> _placeOrderHandler;

        public WholesaleOrdersPlacementController(CommandHandler<PlaceOrder, OrderPlaced> placeOrderHandler) =>
            _placeOrderHandler = placeOrderHandler;

        [HttpPut]
        public async Task<NoContentResult> Place(Guid id)
        {
            await _placeOrderHandler.Handle(new PlaceOrder(id));
            // TODO: change to SeeOther
            return NoContent();
        }
    }
}