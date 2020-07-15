using System;
using JetBrains.Annotations;

namespace MyCompany.Crm.TechnicalStuff.Crud.Results
{
    public readonly struct Deleted : IEquatable<Deleted>
    {
        [PublicAPI] public Guid Id { get; }
        [PublicAPI] public bool WasPresent { get; }

        public Deleted(Guid id, bool wasPresent)
        {
            Id = id;
            WasPresent = wasPresent;
        }

        public bool Equals(Deleted other) => (Id, WasPresent).Equals((other.Id, other.WasPresent));

        public override bool Equals(object obj) => obj is Deleted other && Equals(other);

        public override int GetHashCode() => (Id, WasPresent).GetHashCode();
    }
}