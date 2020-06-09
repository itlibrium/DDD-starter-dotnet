using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStuff.Crud.Api;
using TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Sales.Orders
{
    [Route("/api/order-headers")]
    public class OrderHeadersController : ControllerBase
    {
        private readonly SalesCrudDao _dao;

        public OrderHeadersController(SalesCrudDao dao) => _dao = dao;

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHeader>> Read(Guid id) => await _dao
            .Read(id, DefaultIncludes)
            .ToOkResult();
        
        [HttpGet]
        public IAsyncEnumerable<OrderHeader> Read(Guid clientId, int skip, int take) => _dao
            .Read<OrderHeader>(query => query
                .Apply(DefaultIncludes)
                .Where(orderHeader => orderHeader.ClientId == clientId)
                .Skip(skip)
                .Take(take));

        [HttpPut("{id}")]
        public Task<ActionResult<OrderHeader>> CreateOrUpdate(Guid id, OrderHeader orderHeader) => _dao
            .Update(id, DefaultIncludes, orderHeader)
            .ToOkResult();

        [HttpDelete("{id}")]
        public Task<StatusCodeResult> Delete(Guid id) => _dao
            .Delete<OrderHeader>(id, DeletePolicy.Soft)
            .ToStatusCodeResult();

        private static readonly QueryConfig<OrderHeader> DefaultIncludes =
            orderHeaders => orderHeaders.Include(i => i.InvoicingDetails);
    }
}