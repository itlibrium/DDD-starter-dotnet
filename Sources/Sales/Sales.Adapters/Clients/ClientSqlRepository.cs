using System.Threading.Tasks;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [DddRepository]
    public class ClientSqlRepository : ClientRepository
    {
        public Task<ClientStatus> GetStatusFor(ClientId clientId) => throw new System.NotImplementedException();
    }
}