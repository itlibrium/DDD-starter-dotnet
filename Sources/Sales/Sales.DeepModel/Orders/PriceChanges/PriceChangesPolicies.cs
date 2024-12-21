using MyCompany.ECommerce.Sales.Clients;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders.PriceChanges;

[DddFactory]
public class PriceChangesPolicies(
    AllowAnyPriceChanges allowAny,
    AllowPriceChangesIfTotalPriceIsLower allowIfTotalPriceIsLower,
    ClientRepository clients)
{
    public async Task<PriceChangesPolicy> ChooseFor(ClientId clientId)
    {
        var clientStatus = await clients.GetStatusFor(clientId);
        return clientStatus switch
        {
            ClientStatus.Normal => allowAny,
            ClientStatus.Vip => allowIfTotalPriceIsLower,
            _ => throw new ArgumentOutOfRangeException(nameof(clientStatus), clientStatus, null)
        };
    }
}