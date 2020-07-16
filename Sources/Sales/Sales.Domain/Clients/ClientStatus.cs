using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Clients
{
    [DddValueObject]
    public enum ClientStatus
    {
        Normal,
        Vip
    }
}