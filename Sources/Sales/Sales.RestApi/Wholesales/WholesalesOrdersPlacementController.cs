using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Wholesale.OrderPlacement;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders/{id}/placement")]
    [ApiVersion("1")]
    public class WholesalesOrdersPlacementController : ControllerBase
    {
        private readonly CommandHandler<PlaceOrder, OrderPlaced> _placeOrderHandler;

        public WholesalesOrdersPlacementController(CommandHandler<PlaceOrder, OrderPlaced> placeOrderHandler) =>
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