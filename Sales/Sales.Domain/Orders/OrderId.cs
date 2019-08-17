using System;

namespace MyCompany.Crm.Sales.Orders
{
    public readonly struct OrderId : IEquatable<OrderId>
    {
        public Guid Value { get; }
        
        public static OrderId New() => new OrderId(Guid.NewGuid());
        
        public static OrderId From(Guid value) => new OrderId(value);
        
        private OrderId(Guid value) => Value = value;

        public bool Equals(OrderId other) => Value.Equals(other.Value);
        public override bool Equals(object obj) => obj is OrderId other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"Order {Value.ToString()}";
    }
}