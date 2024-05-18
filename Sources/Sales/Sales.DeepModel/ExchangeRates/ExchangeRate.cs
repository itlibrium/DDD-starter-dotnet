using System;
using System.Globalization;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.ExchangeRates
{
    [DddValueObject]
    public struct ExchangeRate : PriceModifier, IEquatable<ExchangeRate>
    {
        public Currency Currency { get; }
        public decimal Value { get; }
        
        public static ExchangeRate Of(Currency toCurrency, decimal value) => new(toCurrency, value);
        
        private ExchangeRate(Currency currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }
        
        public Money ApplyOn(Money price)
        {
            if (price.Currency != Currency.PLN) throw new DomainError();
            return Money.Of(price.Value * Value, Currency);
        }

        public static Money operator *(Money money, ExchangeRate exchangeRate) => exchangeRate.ApplyOn(money);

        public bool Equals(ExchangeRate other) => (To: Currency, Value).Equals((other.Currency, other.Value));
        public override bool Equals(object obj) => obj is ExchangeRate other && Equals(other);
        public override int GetHashCode() => (To: Currency, Value).GetHashCode();

        public override string ToString() => 
            $"{Value.ToString(CultureInfo.InvariantCulture)} {Currency.ToCode()}/{Currency.PLN.ToCode()}";
    }
}