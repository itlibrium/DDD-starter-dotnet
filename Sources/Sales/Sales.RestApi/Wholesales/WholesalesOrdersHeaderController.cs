using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.TechnicalStuff.Crud.Api;
using MyCompany.Crm.TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Sales.Wholesales
{
    [ApiController]
    [Route("/rest/wholesales/orders/{id}/header")]
    [ApiVersion("1")]
    public class WholesalesOrdersHeaderController : ControllerBase
    {
        private readonly SalesCrudDao _dao;

        public WholesalesOrdersHeaderController(SalesCrudDao dao) => _dao = dao;

        [HttpGet]
        public async Task<ActionResult<OrderHeader>> Read(Guid id)
        {
            await CheckIfOrderExists(id);
            return await _dao
                .Read(id, DefaultIncludes)
                .ToOkResult();
        }

        [HttpPut]
        public Task<ActionResult<OrderHeader>> CreateOrUpdate(Guid id, OrderHeader orderHeader) => _dao
            .Update(id, DefaultIncludes, orderHeader)
            .ToOkResult();

        private Task CheckIfOrderExists(Guid orderId) => throw new NotImplementedException();

        private static readonly QueryConfig<OrderHeader> DefaultIncludes =
            orderHeaders => orderHeaders.Include(i => i.InvoicingDetails);
    }
}