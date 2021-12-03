using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ProcessModel;

namespace MyCompany.Crm.Sales.Wholesale.OrderModification
{
    [DddAppService]
    public class AddToOrderHandler : CommandHandler<AddToOrder, AddedToOrder>
    {
        private readonly OrderRepository _orders;
        private readonly OrderEventsOutbox _eventsOutbox;

        public AddToOrderHandler(OrderRepository orders, OrderEventsOutbox eventsOutbox)
        {
            _orders = orders;
            _eventsOutbox = eventsOutbox;
        }

        public async Task<AddedToOrder> Handle(AddToOrder command)
        {
            var (orderId, productAmount) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            order.Add(productAmount);
            await _orders.Save(order);
            // var allOrderDetails = _readModels.Get(orderId)
            // allOrderDetails.Apply(order.NewEvents)
            // albo
            // allOrderDetails.AddProductAmount(productAmount)
            // _readModels.Save(allOrderDetails)
            var addedToOrder = CreateEventFrom(orderId, productAmount);
            _eventsOutbox.Add(addedToOrder);
            return addedToOrder;
        }

        private static (OrderId, ProductAmount) CreateDomainModelFrom(AddToOrder command) => (
            OrderId.From(command.OrderId),
            ProductAmount.Of(
                ProductId.From(command.ProductId), 
                command.Amount, 
                command.UnitCode.ToDomainModel<AmountUnit>()));
        
        private static AddedToOrder CreateEventFrom(OrderId orderId, ProductAmount productAmount) => 
            new AddedToOrder(orderId.Value, 
                productAmount.ProductId.Value, 
                productAmount.Amount.Value, 
                productAmount.Amount.Unit.ToCode());
    }
}