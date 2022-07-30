using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyCompany.Crm.TechnicalStuff.ValueObjects;

public static class ValueObjectExtensions
{
    public static IEnumerable<ValueObjectMeta> GetValueObjectsMeta(this Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            if (type.IsInterface || (type.IsClass && type.IsAbstract))
                continue;
            if (!type.IsValueObject(out var valueType))
                continue;
            yield return new ValueObjectMeta(type, valueType!);
        }
    }

    public static bool IsValueObject(this Type type, out Type? valueType)
    {
        var valueObjectInterfaces = type.GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ValueObject<>))
            .ToList();
        switch (valueObjectInterfaces.Count)
        {
            case 0:
                valueType = null;
                return false;
            case 1:
                valueType = valueObjectInterfaces[0].GetGenericArguments()[0];
                return true;
            case > 1:
                throw new NotSupportedException(
                    "Value Object should not implement more than one ValueObject<> interface");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}