using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.Wholesale.OrderPlacement;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using PlaceOrder = MyCompany.ECommerce.Sales.OnlineSale.OrderPlacement.PlaceOrder;

namespace MyCompany.ECommerce.Sales.OnlineSale
{
    [ApiController]
    [Route("rest/online-sales/orders")]
    [ApiVersion("1")]
    public class OnlineSaleOrdersController : ControllerBase
    {
        private readonly CommandHandler<PlaceOrder, OrderPlaced> _placeOrderHandler;
        private readonly OrderDetailsFinder _orderDetailsFinder;

        public OnlineSaleOrdersController(CommandHandler<PlaceOrder, OrderPlaced> placeOrderHandler,
            OrderDetailsFinder orderDetailsFinder)
        {
            _placeOrderHandler = placeOrderHandler;
            _orderDetailsFinder = orderDetailsFinder;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Place(PlaceOrder placeOrder)
        {
            var orderPlaced = await _placeOrderHandler.Handle(placeOrder);
            // Returning value works only if read model is created synchronously.
            // var orderDetails = await _orderDetailsFinder.GetBy(orderPlaced.OrderId);
            return CreatedAtAction("Get", new {id = orderPlaced.OrderId}, null /*orderDetails*/);
        }

        [HttpGet("{id}")]
        public async Task<OrderDetails> Get(Guid id) => await _orderDetailsFinder.GetBy(id);
    }
}