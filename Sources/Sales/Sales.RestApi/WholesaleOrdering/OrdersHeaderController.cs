using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering
{
    [ApiController]
    [Route("/rest/wholesale-ordering/orders/{id}/header")]
    [ApiVersion("1")]
    public class OrdersHeaderController : ControllerBase
    {
        private readonly SalesCrudOperations _operations;

        public OrdersHeaderController(SalesCrudOperations operations) => _operations = operations;

        [HttpGet]
        public async Task<ActionResult<OrderHeader>> Read(Guid id) => await _operations
            .Read(id, DefaultIncludes)
            .ToOkResult();

        [HttpPut]
        public Task<ActionResult<OrderHeader>> Update(Guid id, OrderHeader orderHeader) => _operations
            .Update(id, DefaultIncludes, orderHeader)
            .ToOkResult();

        private static readonly QueryConfig<OrderHeader> DefaultIncludes =
            orderHeaders => orderHeaders.Include(i => i.InvoicingDetails);
    }
}