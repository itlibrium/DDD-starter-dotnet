using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalStuff.Crud;
using TechnicalStuff.Crud.Api;
using TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Sales.Orders
{
    [Route("/api/order-headers/{orderId}/notes")]
    public class OrderHeadersNotesController : ControllerBase
    {
        private readonly SalesCrudDao _dao;

        public OrderHeadersNotesController(SalesCrudDao dao) => _dao = dao;

        [HttpPost]
        public async Task<ActionResult<OrderNote>> Create(Guid orderId, OrderNote note)
        {
            await CheckIfOrderExists(orderId);
            return await _dao.Create(note).ToCreatedAtActionResult(createdNote => new
            {
                orderId = createdNote.OrderId,
                id = createdNote.Id
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderNote>> Read(Guid orderId, Guid id)
        {
            await CheckIfOrderExists(orderId);
            return await _dao.Read<OrderNote>(id).ToOkResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderNote>> Update(Guid orderId, Guid id, OrderNote note)
        {
            await CheckIfOrderExists(orderId);
            return await _dao.Update(id, note).ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(Guid orderId, Guid id)
        {
            await CheckIfOrderExists(orderId);
            return await _dao.Delete<OrderNote>(id, DeletePolicy.Hard).ToStatusCodeResult();
        }

        private async Task CheckIfOrderExists(Guid orderId)
        {
            if (!await _dao.CheckIfExists<OrderHeader>(orderId))
                throw new CrudEntityNotFound(typeof(OrderHeader), orderId);
        }
    }
}