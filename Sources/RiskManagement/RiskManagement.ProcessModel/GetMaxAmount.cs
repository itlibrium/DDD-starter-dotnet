using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.RiskManagement;

public record GetMaxAmount(string ClientId) : Command;