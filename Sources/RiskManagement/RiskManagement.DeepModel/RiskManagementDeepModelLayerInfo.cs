using System.Reflection;
using JetBrains.Annotations;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology.CleanArchitecture;

[assembly: EntitiesLayer]
[assembly: DomainModel]

namespace MyCompany.ECommerce.RiskManagement;

[UsedImplicitly]
public class RiskManagementDeepModelLayerInfo
{
    public static Assembly Assembly => typeof(RiskManagementDeepModelLayerInfo).Assembly;
}