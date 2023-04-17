using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Products
{
    [DddValueObject]
    public enum AmountUnit
    {
        Unit,
        Box,
        Palette
    }
}