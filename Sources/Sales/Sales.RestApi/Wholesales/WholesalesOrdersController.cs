using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Wholesale.CreateOrder;
using MyCompany.Crm.TechnicalStuff.UseCases;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders")]
    [ApiVersion("1")]
    public class WholesalesOrdersController : ControllerBase
    {
        private readonly CommandHandler<CreateOrder, OrderCreated> _createOrderHandler;
        private readonly OrderReadModelDao _orderReadModelDao;

        public WholesalesOrdersController(CommandHandler<CreateOrder, OrderCreated> createOrderHandler,
            OrderReadModelDao orderReadModelDao)
        {
            _createOrderHandler = createOrderHandler;
            _orderReadModelDao = orderReadModelDao;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Create(CreateOrder createOrder)
        {
            var orderCreated = await _createOrderHandler.Handle(createOrder);
            // Returning value works only if read model is created synchronously.
            var order = await _orderReadModelDao.GetBy(orderCreated.OrderId);
            return CreatedAtAction("Get", new {id = orderCreated.OrderId}, order);
        }

        [HttpGet("{id}")]
        public async Task<OrderReadModel> Get(Guid id) => await _orderReadModelDao.GetBy(id);
    }
}