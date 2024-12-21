namespace MyCompany.ECommerce.TechnicalStuff.ValueObjects;

public interface ValueObject<T>
{
    T Value { get; init; }
}