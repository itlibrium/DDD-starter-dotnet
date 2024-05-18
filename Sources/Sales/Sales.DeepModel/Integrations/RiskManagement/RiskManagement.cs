using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;

namespace MyCompany.ECommerce.Sales.Integrations.RiskManagement;

public interface RiskManagement
{
    Task<Money> GetMaxOrderTotalCostFor(ClientId clientId);
}