using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Wholesale;
using MyCompany.Crm.Sales.Wholesale.OrderCreation;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("rest/wholesales/orders")]
    [ApiVersion("1")]
    public class WholesalesOrdersController : ControllerBase
    {
        private readonly CommandHandler<CreateOrder, OrderCreated> _createOrderHandler;
        private readonly OrderDetailsFinder _orderDetailsFinder;

        public WholesalesOrdersController(CommandHandler<CreateOrder, OrderCreated> createOrderHandler,
            OrderDetailsFinder orderDetailsFinder)
        {
            _createOrderHandler = createOrderHandler;
            _orderDetailsFinder = orderDetailsFinder;
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> Create(CreateOrder createOrder)
        {
            var orderCreated = await _createOrderHandler.Handle(createOrder);
            // Returning value works only if read model is created synchronously.
            var orderDetails = await _orderDetailsFinder.GetBy(orderCreated.OrderId);
            return CreatedAtAction("Get", new {id = orderCreated.OrderId}, orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<AllOrderDetails> Get(Guid id) => await _orderDetailsFinder.GetBy(id);
    }
}