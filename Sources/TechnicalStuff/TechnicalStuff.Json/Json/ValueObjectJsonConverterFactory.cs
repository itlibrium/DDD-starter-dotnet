using System.Text.Json;
using System.Text.Json.Serialization;
using MyCompany.ECommerce.TechnicalStuff.ValueObjects;

namespace MyCompany.ECommerce.TechnicalStuff.Json.Json;

public class ValueObjectJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsValueObject(out var valueType) &&
        IsValueTypeSupported(valueType!);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (!typeToConvert.IsValueType)
            throw new NotSupportedException();
        if (!typeToConvert.IsValueObject(out var valueType))
            throw new NotSupportedException();
        if (valueType == typeof(long))
            return (JsonConverter)Activator.CreateInstance(
                typeof(LongValueObjectJsonConverter<>).MakeGenericType(typeToConvert))!;
        if (valueType == typeof(string))
            return (JsonConverter)Activator.CreateInstance(
                typeof(StringValueObjectJsonConverter<>).MakeGenericType(typeToConvert))!;
        if (valueType == typeof(decimal))
            return (JsonConverter)Activator.CreateInstance(
                typeof(DecimalValueObjectJsonConverter<>).MakeGenericType(typeToConvert))!;
        if (valueType == typeof(Guid))
            return (JsonConverter)Activator.CreateInstance(
                typeof(GuidValueObjectJsonConverter<>).MakeGenericType(typeToConvert))!;
        throw new NotSupportedException();
    }

    

    private static bool IsValueTypeSupported(Type valueType) =>
        valueType == typeof(long) ||
        valueType == typeof(string) ||
        valueType == typeof(decimal) ||
        valueType == typeof(Guid);
}