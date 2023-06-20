using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[Process(FullName, ApplyOnNamespace = true)]
public class RiskScorePublicationProcess
{
    public const string Name = "Risk score publication";
    public const string FullName = RiskManagementProcess.Name + "." + Name;
}