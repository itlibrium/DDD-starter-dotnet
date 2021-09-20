using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Commons
{
    [DddValueObject]
    public readonly struct Money : IEquatable<Money>
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public bool IsEmpty => Currency == Currency.Undefined;

        public static Money Empty() => new Money();
        public static Money Zero(Currency currency) => new Money(0, currency);
        public static Money Of(decimal value, Currency currency) => new Money(value, currency);

        private Money(decimal value, Currency currency)
        {
            if (currency == Currency.Undefined)
                throw new ArgumentException($"Currency can not be {nameof(Currency.Undefined)}", nameof(currency));
            Value = value;
            Currency = currency;
        }

        public static Money operator +(Money x, Money y) => Calculate(x, y, (a, b) => a + b);
        public static Money operator -(Money x, Money y) => Calculate(x, y, (a, b) => a - b);

        private static Money Calculate(Money x, Money y, Func<decimal, decimal, decimal> calculate)
        {
            if (x.IsEmpty) return y;
            if (y.IsEmpty) return x;
            CheckCurrencies(x, y, true);
            return new Money(calculate(x.Value, y.Value), x.Currency);
        }

        public static Money operator *(Money x, int y) => Calculate(x, y, (a, b) => a * b);
        public static Money operator /(Money x, int y) => Calculate(x, y, (a, b) => a / b);
        public static Money operator *(Money x, decimal y) => Calculate(x, y, (a, b) => a * b);
        public static Money operator /(Money x, decimal y) => Calculate(x, y, (a, b) => a / b);

        public static Money operator *(Money x, Percentage y) => Calculate(x, y.Fraction, (a, b) => a * b);

        private static Money Calculate<T>(Money x, T y, Func<decimal, T, decimal> calculate) => x.IsEmpty
            ? Empty()
            : new Money(calculate(x.Value, y), x.Currency);

        public static Percentage operator /(Money x, Money y)
        {
            CheckCurrencies(x, y, false);
            return Percentage.Of((int) Math.Round((x.Value / y.Value) * 100, 0));
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
            CheckCurrencies(x, y, false);
            return compare(x.Value, y.Value);
        }

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void CheckCurrencies(Money x, Money y, bool allowEmpty)
        {
            if (!allowEmpty && (x.IsEmpty || y.IsEmpty))
                throw new DomainError();
            if (x.Currency != y.Currency)
                throw new DomainError();
        }

        public override bool Equals(object obj) => obj is Money other && Equals(other);
        public bool Equals(Money other) => (Value, Currency).Equals((other.Value, other.Currency));
        public override int GetHashCode() => (Value, Currency).GetHashCode();

        public override string ToString() =>
            $"{Value.ToString("F", CultureInfo.InvariantCulture)} {Currency.ToCode()}";
    }
}