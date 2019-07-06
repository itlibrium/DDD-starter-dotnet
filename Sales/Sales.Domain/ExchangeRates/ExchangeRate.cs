using System;
using System.Globalization;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.ExchangeRates
{
    public struct ExchangeRate : PriceModifier, IEquatable<ExchangeRate>
    {
        public Currency Currency { get; }
        public decimal Value { get; }
        
        public ExchangeRate Of(Currency toCurrency, decimal value) => new ExchangeRate(toCurrency, value);
        
        private ExchangeRate(Currency currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }
        
        public Money ApplyOn(Money price)
        {
            if (price.Currency != Currency.PLN) throw new DomainException();
            return Money.Of(price.Value * Value, Currency);
        }

        public static Money operator *(Money money, ExchangeRate exchangeRate) => exchangeRate.ApplyOn(money);

        public bool Equals(ExchangeRate other) => (To: Currency, Value).Equals((other.Currency, other.Value));
        public override bool Equals(object obj) => obj is ExchangeRate other && Equals(other);
        public override int GetHashCode() => (To: Currency, Value).GetHashCode();

        public override string ToString() => 
            $"{Value.ToString(CultureInfo.InvariantCulture)} {Currency.GetEnumName()}/{Currency.PLN.GetEnumName()}";
    }
}