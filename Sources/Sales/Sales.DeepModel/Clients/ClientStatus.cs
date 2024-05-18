using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Clients
{
    [DddValueObject]
    public enum ClientStatus
    {
        Normal,
        Vip
    }
}