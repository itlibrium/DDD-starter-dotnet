using System.Collections.Immutable;

namespace MyCompany.ECommerce.TechnicalStuff;

public static class HashCodeExtensions
{
    public static HashCode CombineWith<T>(this HashCode hashCode, T value)
    {
        hashCode.Add(value);
        return hashCode;
    }
        
    public static HashCode CombineWith<T>(this HashCode hashCode, ImmutableArray<T> array)
    {
        var length = array.Length;
        for (var i = 0; i < length; i++) hashCode.Add(array[i]);
        return hashCode;
    }
        
    public static HashCode CombineWith<T>(this HashCode hashCode, IEnumerable<T> enumerable)
    {
        foreach (var item in enumerable) hashCode.Add(item);
        return hashCode;
    }
}