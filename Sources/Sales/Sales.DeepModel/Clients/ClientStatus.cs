using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [DddValueObject]
    public enum ClientStatus
    {
        Normal,
        Vip
    }
}