using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Payments;

[Process(Name, ApplyOnNamespace = true)]
public static class PaymentProcess
{
    public const string Name = "Payment";
}