using System;
using JetBrains.Annotations;

namespace MyCompany.ECommerce.TechnicalStuff.Crud
{
    public class CrudEntityNotFound : Exception
    {
        [PublicAPI] public Type Type { get; }
        [PublicAPI] public Guid Id { get; }

        public CrudEntityNotFound(Type type, Guid id)
            : base($"Entity not found. Type: {type.FullName}, Id: {id.ToString()}")
        {
            Type = type;
            Id = id;
        }
    }
}