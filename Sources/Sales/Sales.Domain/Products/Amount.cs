using System;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Products
{
    public readonly struct Amount : IEquatable<Amount>
    {
        public int Value { get; }
        public AmountUnit Unit { get; }

        public static Amount Of(int value, AmountUnit unit) => new Amount(value, unit);
        
        private Amount(int value, AmountUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public static Amount operator +(Amount x, Amount y)
        {
            CheckUnits(x, y);
            return new Amount(x.Value + y.Value, x.Unit);
        }
        
        public static Amount operator -(Amount x, Amount y)
        {
            CheckUnits(x, y);
            return new Amount(x.Value - y.Value, x.Unit);
        }

        private static void CheckUnits(Amount x, Amount y)
        {
            if (x.Unit != y.Unit) throw new DomainException();
        }

        public bool Equals(Amount other) => (Value, Unit).Equals((other.Value, other.Unit));
        public override bool Equals(object obj) => obj is Amount other && Equals(other);
        public override int GetHashCode() => (Value, Unit).GetHashCode();

        public override string ToString() => $"{Value.ToString()} {Unit.ToCode()}";
    }
}