using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyCompany.Crm.TechnicalStuff.ValueObjects;

namespace MyCompany.Crm.TechnicalStuff.Json.Json;

public class DecimalValueObjectJsonConverter<TValueObject> : JsonConverter<TValueObject>
    where TValueObject : struct, ValueObject<decimal>
{
    public override TValueObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null or JsonTokenType.None)
            throw new InvalidOperationException();
        return new TValueObject { Value = decimal.Parse(reader.GetString()!) };
    }

    public override void Write(Utf8JsonWriter writer, TValueObject valueObject, JsonSerializerOptions options) =>
        writer.WriteStringValue(valueObject.Value.ToString("N2", NumberFormatInfo.InvariantInfo));
}