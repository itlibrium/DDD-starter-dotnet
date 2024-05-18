using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[UsedImplicitly]
public class GetRiskScoreHandler : QueryHandler<GetRiskScore, decimal>
{
    [UseCase(nameof(GetRiskScore), Process = RiskScorePublicationProcess.Name)]
    public Task<decimal> Handle(GetRiskScore query)
    {
        throw new NotImplementedException();
    }
}