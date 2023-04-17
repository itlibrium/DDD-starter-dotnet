using P3Model.Annotations.Domain.StaticModel.DDD;

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