using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.ProductsDelivery.Requesting;

[UsedImplicitly]
[ProcessStep(nameof(RequestDelivery), Process = ProductsDeliveryProcess.FullName)]
public class RequestDeliveryHandler : CommandHandler<RequestDelivery>
{
    public Task Handle(RequestDelivery command)
    {
        throw new NotImplementedException();
    }
}