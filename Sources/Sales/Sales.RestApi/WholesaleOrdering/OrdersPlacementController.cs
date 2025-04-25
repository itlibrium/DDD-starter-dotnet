using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[ApiController]
[Route("rest/wholesale-ordering/orders/{id}/placement")]
[ApiVersion("1")]
public class OrdersPlacementController : ControllerBase
{
    private readonly CommandHandler<PlaceOrder, OrderPlaced> _placeOrderHandler;

    public OrdersPlacementController(CommandHandler<PlaceOrder, OrderPlaced> placeOrderHandler) =>
        _placeOrderHandler = placeOrderHandler;

    [HttpPut]
    public async Task<NoContentResult> Place(Guid id)
    {
        await _placeOrderHandler.Handle(new PlaceOrder(id));
        // TODO: change to SeeOther
        return NoContent();
    }
}