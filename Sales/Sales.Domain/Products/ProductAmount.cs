using System;
using System.Collections.Generic;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Products
{
    public readonly struct ProductAmount : IEquatable<ProductAmount>
    {
        public ProductId ProductId { get; }
        public int Value { get; }
        public AmountUnit Unit { get; }

        public static ProductAmount Of(ProductId productId, int value, AmountUnit unit) =>
            new ProductAmount(productId, value, unit);
        
        private ProductAmount(ProductId productId, int value, AmountUnit unit)
        {
            ProductId = productId;
            Value = value;
            Unit = unit;
        }
        
        public IEnumerable<ProductAmount> ToEnumerable() => new[] {this};

        public override bool Equals(object obj) => obj is ProductAmount other && Equals(other);
        public bool Equals(ProductAmount other) =>
            (ProductId, Value, Unit).Equals((other.ProductId, other.Value, other.Unit));
        public override int GetHashCode() => (ProductId.Value, Value, Unit).GetHashCode();

        public override string ToString() => $"Product: {ProductId.ToString()} {Value.ToString()} {Unit.GetEnumName()}";
    }
}