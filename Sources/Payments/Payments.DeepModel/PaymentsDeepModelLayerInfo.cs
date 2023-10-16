using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Payments;

[UsedImplicitly]
public class PaymentsDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsDeepModelLayerInfo).Assembly;
}