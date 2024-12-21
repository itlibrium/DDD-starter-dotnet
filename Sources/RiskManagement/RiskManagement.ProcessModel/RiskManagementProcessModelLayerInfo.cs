using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: UseCasesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.RiskManagement;

[UsedImplicitly]
public class RiskManagementProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(RiskManagementProcessModelLayerInfo).Assembly;
}