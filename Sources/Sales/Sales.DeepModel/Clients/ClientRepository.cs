using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Clients;

[DddRepository]
public interface ClientRepository
{
    Task<ClientStatus> GetStatusFor(ClientId clientId);
}