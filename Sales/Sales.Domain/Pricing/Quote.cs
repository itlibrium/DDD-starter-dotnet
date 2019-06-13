using System;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.ExchangeRates;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing
{
    public readonly struct Quote : IEquatable<Quote>
    {
        public ProductAmount ProductAmount { get; }
        public Money Price { get; }

        public static Quote For(ProductAmount productAmount, Money price) => new Quote(productAmount, price);
        
        private Quote(ProductAmount productAmount, Money price)
        {
            ProductAmount = productAmount;
            Price = price;
        }
        
        public Quote ChangePrice(Money newPrice) => new Quote(ProductAmount, newPrice);
        
        public Quote ChangeCurrency(in ExchangeRate exchangeRate) => ChangePrice(Price * exchangeRate);

        public bool Equals(Quote other) => (Amount: ProductAmount, Price).Equals((other.ProductAmount, other.Price));
        public override bool Equals(object obj) => obj is Quote other && Equals(other);
        public override int GetHashCode() => (Amount: ProductAmount, Price).GetHashCode();

        public override string ToString() => $"{ProductAmount.ToString()} for {Price.ToString()}";
    }
}