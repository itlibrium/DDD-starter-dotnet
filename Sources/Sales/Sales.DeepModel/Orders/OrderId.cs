using System;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;
using MyCompany.Crm.TechnicalStuff.ValueObjects;

namespace MyCompany.Crm.Sales.Orders
{
    [DddValueObject]
    public readonly struct OrderId : ValueObject<Guid>, IEquatable<OrderId>
    {
        public Guid Value { get; init; }
        
        public static OrderId New() => new(Guid.NewGuid());
        
        public static OrderId From(Guid value) => new(value);
        
        private OrderId(Guid value) => Value = value;

        public bool Equals(OrderId other) => Value.Equals(other.Value);
        public override bool Equals(object obj) => obj is OrderId other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"Order {Value.ToString()}";
    }
}