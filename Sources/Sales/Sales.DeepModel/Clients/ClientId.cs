using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Clients;

[DddValueObject]
public readonly struct ClientId : IEquatable<ClientId>
{
    public Guid Value { get; }

    public static ClientId New() => new(Guid.NewGuid());
    public static ClientId From(Guid value) => new(value);
    private ClientId(Guid value) => Value = value;

    public bool Equals(ClientId other) => Value.Equals(other.Value);
    public override bool Equals(object obj) => obj is ClientId other && Equals(other);
    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => $"Client: {Value.ToString()}";
}