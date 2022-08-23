using System;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ValueObjects;

namespace MyCompany.Crm.Sales.Orders
{
    [DddValueObject]
    public readonly record struct OrderId(Guid Value) : ValueObject<Guid>
    {
        public static OrderId New() => new(Guid.NewGuid());
        
        public static OrderId From(Guid value) => new(value);
    }
}