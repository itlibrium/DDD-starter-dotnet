using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.RiskManagement;

[Process(Name, ApplyOnNamespace = true)]
public static class RiskManagementProcess
{
    public const string Name = "Risk management";
}