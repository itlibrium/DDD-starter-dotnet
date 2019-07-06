using System;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public readonly struct ProductDiscount : IEquatable<ProductDiscount>
    {
        public ProductId ProductId { get; }
        public AmountUnit AmountUnit { get; }
        public Discount Discount { get; }

        public static ProductDiscount Of(ProductId productId, AmountUnit amountUnit, Discount discount) =>
            new ProductDiscount(productId, amountUnit, discount);
        
        private ProductDiscount(ProductId productId, AmountUnit amountUnit, Discount discount)
        {
            ProductId = productId;
            AmountUnit = amountUnit;
            Discount = discount;
        }

        public bool Equals(ProductDiscount other) => (ProductId, AmountUnit, Discount)
            .Equals((other.ProductId, other.AmountUnit, other.Discount));
        public override bool Equals(object obj) => obj is ProductDiscount other && Equals(other);
        public override int GetHashCode() => (ProductId, AmountUnit, Discount).GetHashCode();

        public override string ToString() =>
            $"{Discount.ToString()} for {AmountUnit.GetEnumName()} of {ProductId.ToString()}";
    }
}