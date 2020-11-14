using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.OnlineSales.PlaceOrder;
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
        private readonly OrderDetailsDao _orderDetailsDao;

        public OnlineSalesOrdersController(CommandHandler<PlaceOrder.PlaceOrder, OrderPlaced> placeOrderHandler,
            OrderDetailsDao orderDetailsDao)
        {
            _placeOrderHandler = placeOrderHandler;
            _orderDetailsDao = orderDetailsDao;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Place(PlaceOrder.PlaceOrder placeOrder)
        {
            var orderPlaced = await _placeOrderHandler.Handle(placeOrder);
            // Returning value works only if read model is created synchronously.
            var order = await _orderDetailsDao.GetBy(orderPlaced.OrderId);
            return CreatedAtAction("Get", new {id = orderPlaced.OrderId}, order);
        }

        [HttpGet("{id}")]
        public async Task<AllOrderDetails> Get(Guid id) => await _orderDetailsDao.GetBy(id);
    }
}