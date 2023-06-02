using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.Crud;
using MyCompany.ECommerce.TechnicalStuff.Crud.Api;
using MyCompany.ECommerce.TechnicalStuff.Crud.Operations;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering
{
    [ApiController]
    [Route("/rest/wholesale-ordering/orders/{orderId}/header/notes")]
    [ApiVersion("1")]
    public class OrdersHeaderNotesController : ControllerBase
    {
        private readonly SalesCrudOperations _operations;

        public OrdersHeaderNotesController(SalesCrudOperations operations) => _operations = operations;

        [HttpPost]
        public async Task<ActionResult<OrderNote>> Create(Guid orderId, OrderNote note)
        {
            await CheckIfOrderExists(orderId);
            return await _operations.Create(note).ToCreatedAtActionResult(createdNote => new
            {
                orderId = createdNote.OrderId,
                id = createdNote.Id
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderNote>> Read(Guid orderId, Guid id)
        {
            await CheckIfOrderExists(orderId);
            return await _operations.Read<OrderNote>(id).ToOkResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderNote>> Update(Guid orderId, Guid id, OrderNote note)
        {
            await CheckIfOrderExists(orderId);
            return await _operations.Update(id, note).ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(Guid orderId, Guid id)
        {
            await CheckIfOrderExists(orderId);
            return await _operations.Delete<OrderNote>(id, DeletePolicy.Hard).ToStatusCodeResult();
        }

        private async Task CheckIfOrderExists(Guid orderId)
        {
            if (!await _operations.CheckIfExists<OrderHeader>(orderId))
                throw new CrudEntityNotFound(typeof(OrderHeader), orderId);
        }
    }
}