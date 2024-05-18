using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Commons;

[DddValueObject]
public readonly struct TaxId(string value) : IEquatable<TaxId>
{
    public string Value { get; } = value;

    public bool Equals(TaxId other) => Value == other.Value;

    public override bool Equals(object obj) => obj is TaxId other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();
}