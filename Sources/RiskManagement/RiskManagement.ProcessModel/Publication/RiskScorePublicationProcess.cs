using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[Process(Name, ApplyOnNamespace = true)]
public class RiskScorePublicationProcess
{
    public const string Name = "Risk score publication";
}