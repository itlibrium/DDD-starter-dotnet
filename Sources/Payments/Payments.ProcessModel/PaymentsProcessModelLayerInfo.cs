using System.Reflection;
using P3Model.Annotations.Technology;

[assembly: Layer("Process Model")]

namespace MyCompany.ECommerce.Payments;

public class PaymentsProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsProcessModelLayerInfo).Assembly;
}