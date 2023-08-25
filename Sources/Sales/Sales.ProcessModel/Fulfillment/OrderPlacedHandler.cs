using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.Sales.OnlineOrdering.OrderPlacement;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Fulfillment;

[UsedImplicitly]
[ProcessStep(nameof(OrderPlaced), Process = FulfillmentProcess.FullName)]
[DddApplicationService]
public class OrderPlacedHandler : DomainEventHandler<OrderPlaced>, DomainEventHandler<MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement.OrderPlaced>
{
    public Task Handle(Message message) => message switch
    {
        OrderPlaced onlineOrderPlaced => Handle(onlineOrderPlaced),
        MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement.OrderPlaced wholesaleOrderPlaced => Handle(wholesaleOrderPlaced),
        _ => throw new ArgumentOutOfRangeException(nameof(message), message, null)
    };

    public Task Handle(OrderPlaced domainEvent)
    {
        throw new NotImplementedException();
    }

    public Task Handle(MyCompany.ECommerce.Sales.WholesaleOrdering.OrderPlacement.OrderPlaced domainEvent)
    {
        throw new NotImplementedException();
    }
}