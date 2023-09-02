using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Payments;

[UsedImplicitly]
public class PaymentsProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(PaymentsProcessModelLayerInfo).Assembly;
}