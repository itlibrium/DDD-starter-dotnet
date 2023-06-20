using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.ProductsDelivery.Requesting;

[ProcessStepContract]
public readonly struct RequestDelivery : Command { }