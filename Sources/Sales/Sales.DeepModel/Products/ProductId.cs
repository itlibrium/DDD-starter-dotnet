using System;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Products
{
    [DddValueObject]
    public readonly struct ProductId : IEquatable<ProductId>
    {
        public Guid Value { get; }

        public static ProductId New() => new(Guid.NewGuid());
        public static ProductId From(Guid value) => new(value);
        private ProductId(Guid value) => Value = value;

        public override bool Equals(object obj) => obj is ProductId other && Equals(other);
        public bool Equals(ProductId other) => Value.Equals(other.Value);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"Product: {Value.ToString()}";
    }
}