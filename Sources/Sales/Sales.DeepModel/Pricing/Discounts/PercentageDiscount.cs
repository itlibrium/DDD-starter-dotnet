using System;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    [DddPolicy]
    [DddValueObject]
    public readonly struct PercentageDiscount : PriceModifier, IEquatable<PercentageDiscount>
    {
        private readonly Percentage _value;

        public static PercentageDiscount Of(Percentage value) => new PercentageDiscount(value);
        
        private PercentageDiscount(Percentage value) => _value = value;

        public Money ApplyOn(Money price) => price * (Percentage.Of100 - _value);

        public bool Equals(PercentageDiscount other) => 
            _value.Equals(other._value);
        public override bool Equals(object obj) => obj is PercentageDiscount other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => $"Discount of {_value.ToString()}";
    }
}