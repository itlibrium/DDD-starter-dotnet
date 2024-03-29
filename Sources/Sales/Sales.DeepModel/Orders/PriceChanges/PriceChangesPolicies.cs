using System;
using System.Threading.Tasks;
using MyCompany.ECommerce.Sales.Clients;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Orders.PriceChanges
{
    [DddFactory]
    public class PriceChangesPolicies
    {
        private readonly AllowAnyPriceChanges _allowAny;
        private readonly AllowPriceChangesIfTotalPriceIsLower _allowIfTotalPriceIsLower;
        private readonly ClientRepository _clients;

        public PriceChangesPolicies(AllowAnyPriceChanges allowAny,
            AllowPriceChangesIfTotalPriceIsLower allowIfTotalPriceIsLower,
            ClientRepository clients)
        {
            _allowAny = allowAny;
            _allowIfTotalPriceIsLower = allowIfTotalPriceIsLower;
            _clients = clients;
        }

        public async Task<PriceChangesPolicy> ChooseFor(ClientId clientId)
        {
            var clientStatus = await _clients.GetStatusFor(clientId);
            return clientStatus switch
            {
                ClientStatus.Normal => _allowAny,
                ClientStatus.Vip => _allowIfTotalPriceIsLower,
                _ => throw new ArgumentOutOfRangeException(nameof(clientStatus), clientStatus, null)
            };
        }
    }
}