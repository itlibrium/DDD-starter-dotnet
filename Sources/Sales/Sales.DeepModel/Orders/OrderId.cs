using MyCompany.ECommerce.TechnicalStuff.ValueObjects;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddValueObject]
public readonly record struct OrderId(Guid Value) : ValueObject<Guid>
{
    public static OrderId New() => new(Guid.NewGuid());
        
    public static OrderId From(Guid value) => new(value);
}