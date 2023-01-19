using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Crud.Api;
using MyCompany.Crm.TechnicalStuff.Crud.Operations;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("/rest/wholesales/orders/{id}/header")]
    [ApiVersion("1")]
    public class WholesalesOrdersHeaderController : ControllerBase
    {
        private readonly SalesCrudOperations _operations;

        public WholesalesOrdersHeaderController(SalesCrudOperations operations) => _operations = operations;

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