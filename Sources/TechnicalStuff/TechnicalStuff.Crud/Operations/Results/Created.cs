using System;

namespace MyCompany.Crm.TechnicalStuff.Crud.Operations.Results {
    public readonly struct Created<TEntity> : IEquatable<Created<TEntity>>
        where TEntity : class
    {
        public TEntity Entity { get; }

        public Created(TEntity entity) => Entity = entity;

        public bool Equals(Created<TEntity> other) => Entity.Equals(other.Entity);

        public override bool Equals(object obj) => obj is Created<TEntity> other && Equals(other);

        public override int GetHashCode() => Entity.GetHashCode();

        public static implicit operator TEntity(Created<TEntity> created) => created.Entity;
    }
}