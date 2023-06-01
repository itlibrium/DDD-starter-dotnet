using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyCompany.ECommerce.TechnicalStuff.ValueObjects;

namespace MyCompany.ECommerce.TechnicalStuff.Json.Json;

public class LongValueObjectJsonConverter<TValueObject> : JsonConverter<TValueObject>
    where TValueObject : struct, ValueObject<long>
{
    public override TValueObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null or JsonTokenType.None)
            throw new InvalidOperationException();
        return new TValueObject { Value = reader.GetInt64() };
    }

    public override void Write(Utf8JsonWriter writer, TValueObject valueObject, JsonSerializerOptions options) =>
        writer.WriteNumberValue(valueObject.Value);
}