using JetBrains.Annotations;

namespace MyCompany.ECommerce.TechnicalStuff.Crud;

public class CrudEntityNotFound(Type type, Guid id)
    : Exception($"Entity not found. Type: {type.FullName}, Id: {id.ToString()}")
{
    [PublicAPI] public Type Type { get; } = type;
    [PublicAPI] public Guid Id { get; } = id;
}