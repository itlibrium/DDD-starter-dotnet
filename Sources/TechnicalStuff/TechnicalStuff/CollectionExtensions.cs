using System;
using System.Collections.Generic;

namespace MyCompany.Crm.TechnicalStuff;

public static class CollectionExtensions
{
    public static void Replace<T>(this ICollection<T> collection, T oldItem, Func<T, T> newItemFactory)
    {
        collection.Remove(oldItem);
        var newItem = newItemFactory(oldItem);
        collection.Add(newItem);
    }
}