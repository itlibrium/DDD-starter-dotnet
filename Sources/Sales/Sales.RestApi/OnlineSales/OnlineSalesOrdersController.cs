using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.OnlineSales
{
    [ApiController]
    [Route("rest/online-sales/orders")]
    [ApiVersion("1")]
    public class OnlineSalesOrdersController : ControllerBase
    {
        private readonly CommandHandler<PlaceOrder.PlaceOrder, OrderPlaced> _placeOrderHandler;
        private readonly OrderDetailsFinder _orderDetailsFinder;

        public OnlineSalesOrdersController(CommandHandler<PlaceOrder.PlaceOrder, OrderPlaced> placeOrderHandler,
            OrderDetailsFinder orderDetailsFinder)
        {
            _placeOrderHandler = placeOrderHandler;
            _orderDetailsFinder = orderDetailsFinder;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Place(PlaceOrder.PlaceOrder placeOrder)
        {
            var orderPlaced = await _placeOrderHandler.Handle(placeOrder);
            // Returning value works only if read model is created synchronously.
            // var orderDetails = await _orderDetailsFinder.GetBy(orderPlaced.OrderId);
            return CreatedAtAction("Get", new {id = orderPlaced.OrderId}, null /*orderDetails*/);
        }

        [HttpGet("{id}")]
        public async Task<AllOrderDetails> Get(Guid id) => await _orderDetailsFinder.GetBy(id);
    }
}