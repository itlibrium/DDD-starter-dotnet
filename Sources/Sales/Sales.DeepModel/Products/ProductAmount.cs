using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Products
{
    [DddValueObject]
    public record ProductAmount(ProductId ProductId, Amount Amount)
    {
        public ProductUnit ProductUnit => ProductUnit.Of(ProductId, Amount.Unit);

        public static ProductAmount Of(ProductId productId, int value, AmountUnit unit) =>
            new(productId, Amount.Of(value, unit));
        
        public static ProductAmount Of(ProductId productId, Amount amount) => new(productId, amount);
        
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "EF")]
        private ProductAmount() : this(default, default!) { }

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
            if (!x.ProductId.Equals(y.ProductId)) throw new DomainError();
        }
    }
}