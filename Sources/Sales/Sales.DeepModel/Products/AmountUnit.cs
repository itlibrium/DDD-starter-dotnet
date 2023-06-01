using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Products
{
    [DddValueObject]
    public enum AmountUnit
    {
        Unit,
        Box,
        Palette
    }
}