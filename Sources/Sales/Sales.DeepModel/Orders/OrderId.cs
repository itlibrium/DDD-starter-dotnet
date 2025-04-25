using MyCompany.ECommerce.TechnicalStuff.ValueObjects;

namespace MyCompany.ECommerce.Sales.Orders;

public readonly record struct OrderId(Guid Value) : ValueObject<Guid>
{
    public static OrderId New() => new(Guid.NewGuid());
        
    public static OrderId From(Guid value) => new(value);
}