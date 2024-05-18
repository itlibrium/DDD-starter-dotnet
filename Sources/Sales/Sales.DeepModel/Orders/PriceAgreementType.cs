using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders
{
    [DddValueObject]
    public enum PriceAgreementType : byte
    {
        Non,
        Temporary,
        Final
    }
}