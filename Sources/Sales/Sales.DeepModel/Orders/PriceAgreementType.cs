using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Orders
{
    [DddValueObject]
    public enum PriceAgreementType : byte
    {
        Non,
        Temporary,
        Final
    }
}