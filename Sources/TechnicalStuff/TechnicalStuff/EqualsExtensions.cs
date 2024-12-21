namespace MyCompany.ECommerce.TechnicalStuff;

public static class EqualsExtensions
{
    public static bool HasSameItemsAs<T>(this IList<T> collection, IList<T> other)
        where T : IEquatable<T>
    {
        if (other.Count != collection.Count) 
            return false;
        var counts = new Dictionary<T, int>(collection.Count);
        for (var i = 0; i < collection.Count; i++)
        {
            var item = collection[i];
            if (counts.ContainsKey(item))
                counts[item]++;
            else
                counts.Add(item, 1);
        }
        for (var i = 0; i < collection.Count; i++)
        {
            var item = other[i];
            if (counts.TryGetValue(item, out var count))
            {
                if (count == 1)
                    counts.Remove(item);
                else
                    counts[item]--;
            }
            else
            {
                return false;
            }
        }
        return counts.Count == 0;
    }
        
    public static bool HasSameItemsAs<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
        IEnumerable<KeyValuePair<TKey, TValue>> other)
        where TValue : IEquatable<TValue>
    {
        var count = 0;
        foreach (var (key, otherValue) in other)
        {
            if (!dictionary.TryGetValue(key, out var value) || !otherValue.Equals(value))
                return false;
            count++;
        }
        return dictionary.Count == count;
    }
        
    public static bool HasSameItemsAs<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
        IEnumerable<KeyValuePair<TKey, TValue>> other,
        Func<TValue, TValue, bool> comparer)
    {
        var count = 0;
        foreach (var (key, otherValue) in other)
        {
            if (!dictionary.TryGetValue(key, out var value) || !comparer(value, otherValue))
                return false;
            count++;
        }
        return dictionary.Count == count;
    }
}