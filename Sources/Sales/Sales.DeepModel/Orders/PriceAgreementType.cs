using P3Model.Annotations.Domain.StaticModel.DDD;

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