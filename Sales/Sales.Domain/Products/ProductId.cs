using System;

namespace MyCompany.Crm.Sales.Products
{
    public readonly struct ProductId : IEquatable<ProductId>
    {
        public Guid Value { get; }

        public static ProductId New() => new ProductId(Guid.NewGuid());
        public static ProductId For(Guid value) => new ProductId(value);
        private ProductId(Guid value) => Value = value;

        public override bool Equals(object obj) => obj is ProductId other && Equals(other);
        public bool Equals(ProductId other) => Value.Equals(other.Value);
        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"ProductId: {Value.ToString()}";
    }
}