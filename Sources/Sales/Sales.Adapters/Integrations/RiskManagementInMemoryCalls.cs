using MyCompany.ECommerce.RiskManagement;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Sales.Integrations;

public class RiskManagementInMemoryCalls(CommandHandler<GetMaxAmount> handler) : RiskManagement.RiskManagementIntegration
{
    public Task<Money> GetMaxOrderTotalCostFor(ClientId clientId)
    {
        throw new NotImplementedException();
    }
}