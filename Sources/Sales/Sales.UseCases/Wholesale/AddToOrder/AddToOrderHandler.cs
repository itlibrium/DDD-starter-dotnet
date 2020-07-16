using System.Threading.Tasks;
using MyCompany.Crm.Sales.Orders;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Wholesale.AddToOrder
{
    public class AddToOrderHandler
    {
        private readonly OrderRepository _orders;

        public AddToOrderHandler(OrderRepository orders) => _orders = orders;

        public async Task<AddedToOrder> Handle(AddToOrder command)
        {
            var (orderId, productAmount) = CreateDomainModelFrom(command);
            var order = await _orders.GetBy(orderId);
            order.Add(productAmount);
            await _orders.Save(order);
            return CreateEventFrom(orderId, productAmount);
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