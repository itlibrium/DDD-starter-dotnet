using System;
using System.Globalization;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Commons
{
    public readonly struct Money : IEquatable<Money>
    {
        public decimal Value { get; }
        public Currency Currency { get; }
        
        public static Money Zero(Currency currency) => new Money(0, currency);
        public static Money Of(decimal value, Currency currency) => new Money(value, currency);
        
        private Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        public static Money operator +(Money x, Money y) => Calculate(x, y, (a, b) => a + b);
        public static Money operator -(Money x, Money y) => Calculate(x, y, (a, b) => a - b);

        private static Money Calculate(Money x, Money y, Func<decimal, decimal, decimal> calculate)
        {
            CheckCurrencies(x, y);
            return new Money(calculate(x.Value, y.Value), x.Currency);
        }
        
        public static Money operator *(Money x, int y) => Calculate(x, y, (a, b) => a * b);
        public static Money operator /(Money x, int y) => Calculate(x, y, (a, b) => a / b);
        public static Money operator *(Money x, decimal y) => Calculate(x, y, (a, b) => a * b);
        public static Money operator /(Money x, decimal y) => Calculate(x, y, (a, b) => a / b);
        
        public static Money operator *(Money x, Percentage y) =>  Calculate(x, y.Fraction, (a, b) => a * b);
        
        private static Money Calculate<T>(Money x, T y, Func<decimal, T, decimal> calculate) => 
            new Money(calculate(x.Value, y), x.Currency);
        
        public static Percentage operator /(Money x, Money y)
        {
            CheckCurrencies(x, y);
            return Percentage.Of((int) Math.Round(x.Value / y.Value, 0));
        }
        
        public static Money Max(Money x, Money y) => x > y ? x : y;

        public static bool operator ==(Money x, Money y) => x.Equals(y);
        public static bool operator !=(Money x, Money y) => !x.Equals(y);
        public static bool operator >(Money x, Money y) => Compare(x, y, (a, b) => a > b);
        public static bool operator <(Money x, Money y) => Compare(x, y, (a, b) => a < b);
        public static bool operator >=(Money x, Money y) => Compare(x, y, (a, b) => a >= b);
        public static bool operator <=(Money x, Money y) => Compare(x, y, (a, b) => a <= b);
        
        private static bool Compare(Money x, Money y, Func<decimal, decimal, bool> compare)
        {
            CheckCurrencies(x, y);
            return compare(x.Value, y.Value);
        }
        
        private static void CheckCurrencies(Money x, Money y)
        {
            if (x.Currency != y.Currency) throw new DomainException();
        }

        public override bool Equals(object obj) => obj is Money other && Equals(other);
        public bool Equals(Money other) => (Value, Currency).Equals((other.Value, other.Currency));
        public override int GetHashCode() => (Value, Currency).GetHashCode();

        public override string ToString() => $"{Value.ToString(CultureInfo.InvariantCulture)} {Currency.GetEnumName()}";
    }
}