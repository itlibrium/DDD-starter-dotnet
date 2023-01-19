namespace MyCompany.Crm.TechnicalStuff.ValueObjects;

public interface ValueObject<T>
{
    T Value { get; init; }
}