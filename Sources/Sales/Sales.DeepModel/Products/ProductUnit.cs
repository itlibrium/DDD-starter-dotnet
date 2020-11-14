using System;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Products
{
    [DddValueObject]
    public readonly struct ProductUnit : IEquatable<ProductUnit>
    {
        public ProductId ProductId { get; }
        public AmountUnit Unit { get; }
        
        public static ProductUnit Of(ProductId productId, AmountUnit unit) => new ProductUnit(productId, unit);

        private ProductUnit(ProductId productId, AmountUnit unit)
        {
            ProductId = productId;
            Unit = unit;
        }
        
        public bool Equals(ProductUnit other) => (ProductId, Unit).Equals((other.ProductId, other.Unit));
        public override bool Equals(object obj) => obj is ProductUnit other && Equals(other);
        public override int GetHashCode() => (ProductId, Unit).GetHashCode();
        
        public override string ToString() => $"{Unit.ToCode()} of {ProductId.ToString()}";
    }
}