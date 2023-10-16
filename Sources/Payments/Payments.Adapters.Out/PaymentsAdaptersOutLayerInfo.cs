using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: AdaptersLayer]

namespace MyCompany.ECommerce.Payments;

[UsedImplicitly]
public static class PaymentsAdaptersOutLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsAdaptersOutLayerInfo).Assembly;
}