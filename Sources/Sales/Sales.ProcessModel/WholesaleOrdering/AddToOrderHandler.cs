using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.People;

namespace MyCompany.ECommerce.Sales.WholesaleOrdering;

[UsedImplicitly]
public class AddToOrderHandler(Order.Repository orders, OrderEventsOutbox eventsOutbox)
    : CommandHandler<AddToOrder, AddedToOrder>
{
    [Actor(Actors.WholesaleClient)]
    public async Task<AddedToOrder> Handle(AddToOrder command)
    {
            var (orderId, productAmount) = CreateDomainModelFrom(command);
            var order = await orders.GetBy(orderId);
            order.Add(productAmount);
            await orders.Save(order);
            // var allOrderDetails = _readModels.Get(orderId)
            // allOrderDetails.Apply(order.NewEvents)
            // albo
            // allOrderDetails.AddProductAmount(productAmount)
            // _readModels.Save(allOrderDetails)
            var addedToOrder = CreateEventFrom(orderId, productAmount);
            eventsOutbox.Add(addedToOrder);
            return addedToOrder;
        }

    private static (OrderId, ProductAmount) CreateDomainModelFrom(AddToOrder command) => (
        OrderId.From(command.OrderId),
        ProductAmount.Of(
            ProductId.From(command.ProductId),
            command.Amount,
            command.UnitCode.ToDomainModel<AmountUnit>()));

    private static AddedToOrder CreateEventFrom(OrderId orderId, ProductAmount productAmount) =>
        new(orderId.Value,
            productAmount.ProductId.Value,
            productAmount.Amount.Value,
            productAmount.Amount.Unit.ToCode());
}