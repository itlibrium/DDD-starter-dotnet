using System.Threading.Tasks;
using MyCompany.Crm.Sales.Clients;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.Integrations.RiskManagement;

public interface RiskManagement
{
    Task<Money> GetMaxOrderTotalCostFor(ClientId clientId);
}