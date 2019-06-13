using System;
using MyCompany.Crm.Sales.Commons;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public readonly struct Discount : IEquatable<Discount>
    {
        private readonly Percentage _percentage;
        private readonly Money _value;
        private readonly bool _isPercentage;
        
        public static Discount Of(Percentage value) => 
            new Discount(value, default, true);
        
        public static Discount Of(Money value) => 
            new Discount(default, value, false);

        private Discount(Percentage percentage, Money value, bool isPercentage)
        {
            _percentage = percentage;
            _value = value;
            _isPercentage = isPercentage;
        }

        public Money ApplyOn(Money price) => _isPercentage
            ? price * (Percentage.Of100 - _percentage)
            : price - _value;

        public bool Equals(Discount other) => (_percentage, _value, IsPercentage: _isPercentage)
            .Equals((other._percentage, other._value, other._isPercentage));
        public override bool Equals(object obj) => obj is Discount other && Equals(other);
        public override int GetHashCode() => (_percentage, _value, IsPercentage: _isPercentage).GetHashCode();

        public override string ToString() => 
            $"Discount of {(_isPercentage ? _percentage.ToString() : _value.ToString())}";
    }
}