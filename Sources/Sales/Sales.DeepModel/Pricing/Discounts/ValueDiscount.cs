using System;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    [DddPolicy]
    [DddValueObject]
    public readonly struct ValueDiscount : PriceModifier, IEquatable<ValueDiscount>
    {
        private readonly Money _value;

        public static ValueDiscount Of(Money value) => new ValueDiscount(value);
        
        private ValueDiscount(Money value) => _value = value;

        public Money ApplyOn(Money price) => Money.Max(price - _value, Money.Zero(price.Currency));

        public bool Equals(ValueDiscount other) => _value.Equals(other._value);
        public override bool Equals(object obj) => obj is ValueDiscount other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => $"Discount of {_value.ToString()}";
    }
}