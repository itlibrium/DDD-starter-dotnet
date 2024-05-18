using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.RiskManagement.Calculation;

[Process(Name, ApplyOnNamespace = true)]
public static class RiskScoreCalculationProcess
{
    public const string Name = "Risk score calculation";
}