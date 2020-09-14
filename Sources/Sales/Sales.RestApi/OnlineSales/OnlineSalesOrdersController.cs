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
        private readonly OrderReadModelDao _orderReadModelDao;

        public OnlineSalesOrdersController(CommandHandler<PlaceOrder.PlaceOrder, OrderPlaced> placeOrderHandler,
            OrderReadModelDao orderReadModelDao)
        {
            _placeOrderHandler = placeOrderHandler;
            _orderReadModelDao = orderReadModelDao;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Place(PlaceOrder.PlaceOrder placeOrder)
        {
            var orderPlaced = await _placeOrderHandler.Handle(placeOrder);
            // Returning value works only if read model is created synchronously.
            var order = await _orderReadModelDao.GetBy(orderPlaced.OrderId);
            return CreatedAtAction("Get", new {id = orderPlaced.OrderId}, order);
        }

        [HttpGet("{id}")]
        public async Task<OrderReadModel> Get(Guid id) => await _orderReadModelDao.GetBy(id);
    }
}