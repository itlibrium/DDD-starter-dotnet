using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Clients
{
    [DddValueObject]
    public enum ClientStatus
    {
        Normal,
        Vip
    }
}