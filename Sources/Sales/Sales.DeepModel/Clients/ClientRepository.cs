using System.Threading.Tasks;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [DddRepository]
    public interface ClientRepository
    {
        Task<ClientStatus> GetStatusFor(ClientId clientId);
    }
}