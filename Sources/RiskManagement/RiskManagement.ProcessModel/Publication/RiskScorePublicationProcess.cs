using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[Process(Name, ApplyOnNamespace = true)]
public class RiskScorePublicationProcess
{
    public const string Name = "Risk score publication";
}