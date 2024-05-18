using System;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.PriceLists
{
    [DddValueObject]
    public readonly struct BasePrice : IEquatable<BasePrice>
    {
        public ProductUnit ProductUnit { get; }
        public Money Price { get; }
        
        public BasePrice Of(ProductUnit productUnit, Money price) => new(productUnit, price);

        private BasePrice(ProductUnit productUnit, Money price)
        {
            ProductUnit = productUnit;
            Price = price;
        }

        public bool Equals(BasePrice other) => (ProductUnit, Price).Equals((other.ProductUnit, other.Price));
        public override bool Equals(object obj) => obj is BasePrice other && Equals(other);
        public override int GetHashCode() => (ProductUnit, Price).GetHashCode();

        public override string ToString() => $"Base price of {ProductUnit.ToString()}: {Price.ToString()}";
    }
}