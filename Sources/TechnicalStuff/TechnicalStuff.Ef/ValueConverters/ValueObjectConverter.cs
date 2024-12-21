using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompany.ECommerce.TechnicalStuff.ValueObjects;

namespace MyCompany.ECommerce.TechnicalStuff.Ef.ValueConverters;

public class ValueObjectConverter<TValueObject, TValue> : ValueConverter<TValueObject, TValue>
    where TValueObject : ValueObject<TValue>, new()
{
    public ValueObjectConverter() : base(ToValue, ToValueObject) { }

    private static Expression<Func<TValueObject, TValue>> ToValue => id => id.Value;

    private static Expression<Func<TValue, TValueObject>> ToValueObject => value => new TValueObject { Value = value };
}