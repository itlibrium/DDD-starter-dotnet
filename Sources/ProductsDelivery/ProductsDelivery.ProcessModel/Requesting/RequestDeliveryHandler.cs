using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.ProductsDelivery.Requesting;

[UsedImplicitly]
public class RequestDeliveryHandler : CommandHandler<RequestDelivery>
{
    [UseCase(nameof(RequestDelivery), Process = ProductsDeliveryProcess.Name)]
    public Task Handle(RequestDelivery command)
    {
        throw new NotImplementedException();
    }
}