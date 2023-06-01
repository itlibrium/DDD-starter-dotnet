using System;
using MyCompany.ECommerce.Sales.Commons;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts
{
    [DddDomainService]
    [DddValueObject]
    public readonly struct PercentageDiscount : PriceModifier, IEquatable<PercentageDiscount>
    {
        private readonly Percentage _value;

        public static PercentageDiscount Of(Percentage value) => new(value);
        
        private PercentageDiscount(Percentage value) => _value = value;

        public Money ApplyOn(Money price) => price * (Percentage.Of100 - _value);

        public bool Equals(PercentageDiscount other) => 
            _value.Equals(other._value);
        public override bool Equals(object obj) => obj is PercentageDiscount other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => $"Discount of {_value.ToString()}";
    }
}