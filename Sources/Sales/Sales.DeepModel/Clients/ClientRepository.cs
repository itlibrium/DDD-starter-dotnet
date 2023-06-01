using System.Threading.Tasks;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Clients
{
    [DddRepository]
    public interface ClientRepository
    {
        Task<ClientStatus> GetStatusFor(ClientId clientId);
    }
}