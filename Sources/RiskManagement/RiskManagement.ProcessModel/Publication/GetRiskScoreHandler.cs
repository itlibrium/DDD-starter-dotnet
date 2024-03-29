using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[UsedImplicitly]
[ProcessStep(nameof(GetRiskScore), Process = RiskScorePublicationProcess.Name)]
public class GetRiskScoreHandler : QueryHandler<GetRiskScore, decimal>
{
    public Task<decimal> Handle(GetRiskScore query)
    {
        throw new NotImplementedException();
    }
}