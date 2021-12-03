using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Wholesale.OrderModification;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders/{orderId}/items")]
    [ApiVersion("1")]
    public class WholesalesOrdersItemsController : ControllerBase
    {
        private readonly CommandHandler<AddToOrder, AddedToOrder> _addToOrderHandler;
        
        public WholesalesOrdersItemsController(CommandHandler<AddToOrder, AddedToOrder> addToOrderHandler) => 
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
}