using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.WholesaleOrdering.OrderModification;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[ApiController]
[Route("rest/wholesale-ordering/orders/{orderId}/items")]
[ApiVersion("1")]
public class OrdersItemsController : ControllerBase
{
    private readonly CommandHandler<AddToOrder, AddedToOrder> _addToOrderHandler;
        
    public OrdersItemsController(CommandHandler<AddToOrder, AddedToOrder> addToOrderHandler) => 
        _addToOrderHandler = addToOrderHandler;

    [HttpPut]
    public async Task<NoContentResult> Add(Guid orderId, OrderItemDto item)
    {
        await _addToOrderHandler.Handle(new AddToOrder(orderId, item.ProductId, item.Amount, item.UnitCode));
        return NoContent();
    }
        
    [HttpDelete]
    public Task<NoContentResult> Remove(Guid orderId, OrderItemDto item)
    {
        // TODO: RemoveOrderItem
        throw new NetworkInformationException();
    }
        
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderItemDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string UnitCode { get; set; }
    }
}