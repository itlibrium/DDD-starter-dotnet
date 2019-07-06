using System;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Pricing.PriceLists
{
    public readonly struct BasePrice : IEquatable<BasePrice>
    {
        public ProductId ProductId { get; }
        public AmountUnit AmountUnit { get; }
        public Money Price { get; }
        
        public BasePrice Of(ProductId productId, AmountUnit amountUnit, Money price) => 
            new BasePrice(productId, amountUnit, price);

        private BasePrice(ProductId productId, AmountUnit amountUnit, Money price)
        {
            ProductId = productId;
            AmountUnit = amountUnit;
            Price = price;
        }

        public bool Equals(BasePrice other) => (ProductId, AmountUnit, Price)
            .Equals((other.ProductId, other.AmountUnit, other.Price));
        public override bool Equals(object obj) => obj is BasePrice other && Equals(other);
        public override int GetHashCode() => (ProductId, AmountUnit, Price).GetHashCode();

        public override string ToString() =>
            $"Base price of {ProductId.ToString()} {AmountUnit.GetEnumName()}: {Price.ToString()}";
    }
}