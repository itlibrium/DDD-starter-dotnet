using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.Fulfillment;

using OnlineOrderPlaced = OnlineOrdering.OrderPlacement.OrderPlaced;
using WholesaleOrderPlaced = WholesaleOrdering.OrderPlacement.OrderPlaced;

[UsedImplicitly]
public class OrderPlacedHandler : DomainEventHandler<OnlineOrderPlaced>, DomainEventHandler<WholesaleOrderPlaced>
{
    public Task Handle(Message message) => message switch
    {
        OnlineOrderPlaced onlineOrderPlaced => Handle(onlineOrderPlaced),
        WholesaleOrderPlaced wholesaleOrderPlaced => Handle(wholesaleOrderPlaced),
        _ => throw new ArgumentOutOfRangeException(nameof(message), message, null)
    };

    [UseCase(nameof(OnlineOrderPlaced), Process = FulfillmentProcess.Name)]
    public Task Handle(OnlineOrderPlaced domainEvent)
    {
        throw new NotImplementedException();
    }

    [UseCase(nameof(WholesaleOrderPlaced), Process = FulfillmentProcess.Name)]
    public Task Handle(WholesaleOrderPlaced domainEvent)
    {
        throw new NotImplementedException();
    }
}