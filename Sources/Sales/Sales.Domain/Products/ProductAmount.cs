using System;

namespace MyCompany.Crm.Sales.Products
{
    public readonly struct ProductAmount : IEquatable<ProductAmount>
    {
        public ProductId ProductId { get; }
        public Amount Amount { get; }

        public ProductUnit ProductUnit => ProductUnit.Of(ProductId, Amount.Unit);

        public static ProductAmount Of(ProductId productId, int value, AmountUnit unit) =>
            new ProductAmount(productId, Amount.Of(value, unit));
        
        public static ProductAmount Of(ProductId productId, Amount amount) => new ProductAmount(productId, amount);
        
        private ProductAmount(ProductId productId, Amount amount)
        {
            ProductId = productId;
            Amount = amount;
        }

        public static ProductAmount operator +(ProductAmount x, ProductAmount y)
        {
            CheckProductId(x, y);
            return Of(x.ProductId, x.Amount + y.Amount);
        }
        
        public static ProductAmount operator -(ProductAmount x, ProductAmount y)
        {
            CheckProductId(x, y);
            return Of(x.ProductId, x.Amount - y.Amount);
        }

        private static void CheckProductId(ProductAmount x, ProductAmount y)
        {
            if (!x.ProductId.Equals(y.ProductId)) throw new DomainException();
        }
        
        public override bool Equals(object obj) => obj is ProductAmount other && Equals(other);
        public bool Equals(ProductAmount other) =>
            (ProductId, Amount).Equals((other.ProductId, other.Amount));
        public override int GetHashCode() => (ProductId, Amount).GetHashCode();

        public override string ToString() => 
            $"Product: {ProductId.ToString()} - {Amount.ToString()}";
    }
}