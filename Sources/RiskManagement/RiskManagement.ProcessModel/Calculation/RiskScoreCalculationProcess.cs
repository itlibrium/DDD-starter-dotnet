using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.RiskManagement.Calculation;

[Process(FullName, ApplyOnNamespace = true)]
public static class RiskScoreCalculationProcess
{
    public const string Name = "Risk score calculation";
    public const string FullName = RiskManagementProcess.Name + "." + Name;
}