using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Payments;

[Process(FullName, ApplyOnNamespace = true)]
public static class PaymentProcess
{
    public const string Name = "Payment";
    public const string FullName = "Sale" + "." + Name;
}