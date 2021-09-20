using System;

namespace MyCompany.Crm.RiscManagement
{
    public readonly struct GetRiskScore
    {
        public Guid ClientId { get; }

        public GetRiskScore(Guid clientId) => ClientId = clientId;
    }
}