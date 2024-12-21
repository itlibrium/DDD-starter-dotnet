using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.RiskManagement.Publication;

public readonly record struct GetRiskScore(Guid ClientId) : Query;