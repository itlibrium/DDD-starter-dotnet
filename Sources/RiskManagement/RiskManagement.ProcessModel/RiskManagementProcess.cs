using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.RiskManagement;

[Process(FullName, ApplyOnNamespace = true)]
public static class RiskManagementProcess
{
    public const string FullName = "Risk management";
}