using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Commons
{
    [DddValueObject]
    public enum Currency
    {
        Undefined,
        PLN,
        USD,
        EUR
    }
}