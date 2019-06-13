using System;
using System.Globalization;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.ExchangeRates
{
    public struct ExchangeRate : IEquatable<ExchangeRate>
    {
        public Currency To { get; }
        public decimal Value { get; }
        
        public ExchangeRate Of(Currency to, decimal value) => new ExchangeRate(to, value);
        
        private ExchangeRate(Currency to, decimal value)
        {
            To = to;
            Value = value;
        }
        
        public static Money operator *(Money money, ExchangeRate exchangeRate)
        {
            if (money.Currency != Currency.PLN) throw new DomainException();
            return Money.Of(money.Value * exchangeRate.Value, exchangeRate.To);
        }

        public bool Equals(ExchangeRate other) => (To, Value).Equals((other.To, other.Value));
        public override bool Equals(object obj) => obj is ExchangeRate other && Equals(other);
        public override int GetHashCode() => (To, Value).GetHashCode();

        public override string ToString() 
            => $"{Value.ToString(CultureInfo.InvariantCulture)} {To.GetEnumName()}/{Currency.PLN.GetEnumName()}";
    }
}