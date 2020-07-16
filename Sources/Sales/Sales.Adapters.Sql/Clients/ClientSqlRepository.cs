using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Metadata;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [Stateless]
    [DddRepository]
    public class ClientSqlRepository : ClientRepository
    {
        public Task<ClientStatus> GetStatusFor(ClientId clientId) => throw new System.NotImplementedException();
    }
}