using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.StaticModel;

namespace MyCompany.ECommerce.RiskManagement.Publication;

[ProcessStepContract]
public readonly record struct GetRiskScore(Guid ClientId) : Query;