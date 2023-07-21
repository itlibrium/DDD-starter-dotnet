using System.Reflection;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology;

[assembly: Layer("Process Model")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Payments;

public class PaymentsProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsProcessModelLayerInfo).Assembly;
}