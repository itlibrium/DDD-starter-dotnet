using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Commons
{
    [DddValueObject]
    public enum Currency
    {
        PLN,
        USD,
        EUR
    }
}