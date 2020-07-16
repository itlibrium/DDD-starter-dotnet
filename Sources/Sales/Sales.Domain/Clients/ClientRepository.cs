using System.Threading.Tasks;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [DddRepository]
    public interface ClientRepository
    {
        Task<ClientStatus> GetStatusFor(ClientId clientId);
    }
}