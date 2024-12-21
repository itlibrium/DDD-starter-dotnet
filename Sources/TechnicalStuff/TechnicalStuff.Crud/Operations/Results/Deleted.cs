using JetBrains.Annotations;

namespace MyCompany.ECommerce.TechnicalStuff.Crud.Operations.Results;

public readonly struct Deleted(Guid id, bool wasPresent) : IEquatable<Deleted>
{
    [PublicAPI] public Guid Id { get; } = id;
    [PublicAPI] public bool WasPresent { get; } = wasPresent;

    public bool Equals(Deleted other) => (Id, WasPresent).Equals((other.Id, other.WasPresent));

    public override bool Equals(object obj) => obj is Deleted other && Equals(other);

    public override int GetHashCode() => (Id, WasPresent).GetHashCode();
}