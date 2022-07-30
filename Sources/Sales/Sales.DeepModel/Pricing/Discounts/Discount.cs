using System;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    [DddPolicy]
    [DddValueObject]
    public readonly struct Discount : PriceModifier, IEquatable<Discount>
    {
        private readonly bool _isPercentage;
        private readonly PercentageDiscount _percentageDiscount;
        private readonly ValueDiscount _valueDiscount;

        public static Discount Percentage(Percentage value) => new(true, PercentageDiscount.Of(value), default);
        
        public static Discount Value(Money value) => new(true, default, ValueDiscount.Of(value));

        private Discount(bool isPercentage, PercentageDiscount percentageDiscount, ValueDiscount valueDiscount)
        {
            _isPercentage = isPercentage;
            _percentageDiscount = percentageDiscount;
            _valueDiscount = valueDiscount;
        }

        public Money ApplyOn(Money price) => _isPercentage
            ? _percentageDiscount.ApplyOn(price)
            : _valueDiscount.ApplyOn(price);

        public bool Equals(Discount other) => (_isPercentage, _percentageDiscount, _valueDiscount)
            .Equals((other._isPercentage, other._percentageDiscount, other._valueDiscount));
        public override bool Equals(object obj) => obj is Discount other && Equals(other);
        public override int GetHashCode() => (_isPercentage, _percentageDiscount, _valueDiscount).GetHashCode();

        public override string ToString() => _isPercentage ? _percentageDiscount.ToString() : _valueDiscount.ToString();
    }
}