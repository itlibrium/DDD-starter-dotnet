using System;
using MyCompany.ECommerce.Sales.Commons;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.Discounts
{
    [DddValueObject]
    public readonly struct ValueDiscount : PriceModifier, IEquatable<ValueDiscount>
    {
        private readonly Money _value;

        public static ValueDiscount Of(Money value) => new(value);
        
        private ValueDiscount(Money value) => _value = value;

        public Money ApplyOn(Money price) => Money.Max(price - _value, Money.Zero(price.Currency));

        public bool Equals(ValueDiscount other) => _value.Equals(other._value);
        public override bool Equals(object? obj) => obj is ValueDiscount other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => $"Discount of {_value}";
    }
}