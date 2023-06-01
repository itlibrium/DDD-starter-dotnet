using System;

namespace MyCompany.ECommerce.RiskManagement
{
    public readonly struct GetRiskScore
    {
        public Guid ClientId { get; }

        public GetRiskScore(Guid clientId) => ClientId = clientId;
    }
}