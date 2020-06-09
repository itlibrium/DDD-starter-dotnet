using System.Threading.Tasks;

namespace MyCompany.Crm.Sales.Clients
{
    public interface ClientRepository
    {
        Task<ClientStatus> GetStatusFor(ClientId clientId);
    }
}