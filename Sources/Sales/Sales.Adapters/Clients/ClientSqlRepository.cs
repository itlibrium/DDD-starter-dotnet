using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MyCompany.ECommerce.Sales.Clients
{
    [UsedImplicitly]
    public class ClientSqlRepository : ClientRepository
    {
        public Task<ClientStatus> GetStatusFor(ClientId clientId) => throw new System.NotImplementedException();
    }
}