using System;

namespace MyCompany.Crm.Sales.Commons
{
    public readonly struct Percentage : IEquatable<Percentage>
    {
        public int Value { get; }
        public decimal Fraction => (decimal) Value / 100;
        
        public static Percentage Of0 => new Percentage(0);
        public static Percentage Of100 => new Percentage(100);
        public static Percentage Of(int value) => new Percentage(value);

        private Percentage(int value) => Value = value;

        public static Percentage operator +(Percentage x, Percentage y) => new Percentage(x.Value + y.Value);
        public static Percentage operator -(Percentage x, Percentage y) => new Percentage(x.Value - y.Value);

        public static bool operator ==(Percentage x, Percentage y) => x.Equals(y);
        public static bool operator !=(Percentage x, Percentage y) => !x.Equals(y);
        public static bool operator >(Percentage x, Percentage y) => x.Value > y.Value;
        public static bool operator <(Percentage x, Percentage y) => x.Value < y.Value;
        public static bool operator >=(Percentage x, Percentage y) => x.Value >= y.Value;
        public static bool operator <=(Percentage x, Percentage y) => x.Value <= y.Value;

        public bool Equals(Percentage other) => Value == other.Value;
        public override bool Equals(object obj) => obj is Percentage other && Equals(other);
        public override int GetHashCode() => Value;

        public override string ToString() => $"{Value.ToString()}%";
    }
    
    public class Percentage2
    {
        public int Value { get; }
        public decimal Fraction => (decimal) Value / 100;
        
        public static Percentage2 Of0 => new Percentage2(0);
        public static Percentage2 Of100 => new Percentage2(100);
        public static Percentage2 Of(int value) => new Percentage2(value);

        private Percentage2(int value) => Value = value;

        public static Percentage2 operator +(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return new Percentage2(x.Value + y.Value);
        }
        public static Percentage2 operator -(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return new Percentage2(x.Value - y.Value);
        }

        public static bool operator ==(Percentage2 x, Percentage2 y) => x != null && x.Equals(y);
        public static bool operator !=(Percentage2 x, Percentage2 y) => x == null || !x.Equals(y);
        public static bool operator >(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Value > y.Value;
        }
        public static bool operator <(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Value < y.Value;
        }
        public static bool operator >=(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Value >= y.Value;
        }
        public static bool operator <=(Percentage2 x, Percentage2 y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            return x.Value <= y.Value;
        }

        public override bool Equals(object obj) => obj is Percentage2 other && Value == other.Value;
        public override int GetHashCode() => Value;

        public override string ToString() => $"{Value.ToString()}%";
    }
}