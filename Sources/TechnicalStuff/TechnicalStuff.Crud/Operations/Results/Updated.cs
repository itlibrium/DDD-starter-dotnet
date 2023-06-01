using System;
using JetBrains.Annotations;

namespace MyCompany.ECommerce.TechnicalStuff.Crud.Operations.Results
{
    public readonly struct Updated : IEquatable<Updated>
    {
        [PublicAPI] public Guid Id { get; }

        public Updated(Guid id) => Id = id;

        public bool Equals(Updated other) => Id.Equals(other.Id);

        public override bool Equals(object obj) => obj is Updated other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }

    public readonly struct Updated<TEntity> : IEquatable<Updated<TEntity>>
        where TEntity : class
    {
        [PublicAPI] public TEntity Entity { get; }

        public Updated(TEntity entity) => Entity = entity;

        public bool Equals(Updated<TEntity> other) => Entity.Equals(other.Entity);

        public override bool Equals(object obj) => obj is Updated<TEntity> other && Equals(other);

        public override int GetHashCode() => Entity.GetHashCode();

        public static implicit operator TEntity(Updated<TEntity> created) => created.Entity;
    }
}