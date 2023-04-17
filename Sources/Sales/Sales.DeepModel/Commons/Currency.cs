using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Commons
{
    [DddValueObject]
    public enum Currency
    {
        PLN,
        USD,
        EUR
    }
}