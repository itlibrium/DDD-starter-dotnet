using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Products;

[DddValueObject]
public enum AmountUnit
{
    Unit,
    Box,
    Palette
}