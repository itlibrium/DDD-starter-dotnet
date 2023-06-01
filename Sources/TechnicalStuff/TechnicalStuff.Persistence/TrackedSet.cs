using System.Collections;

namespace MyCompany.ECommerce.TechnicalStuff.Persistence;

public class TrackedSet<TItem, TDbItem> : IReadOnlySet<TItem>
    where TItem : IEquatable<TItem>
    where TDbItem : IEquatable<TDbItem>
{
    private readonly Dictionary<TItem, TDbItem> _original = new();
    private readonly HashSet<TItem> _currentItems = new();
    private readonly Func<TItem, TDbItem> _toDbItem;

    private List<TItem>? _added;
    private List<TItem>? _removed;

    public int Count => _currentItems.Count;

    public TrackedSet(IEnumerable<TDbItem> dbItems,
        Func<TItem, TDbItem> toDbItem,
        Func<TDbItem, TItem> toItem)
    {
        foreach (var dbItem in dbItems)
        {
            var item = toItem(dbItem);
            _original.Add(item, dbItem);
            _currentItems.Add(item);
        }
        _toDbItem = toDbItem;
    }

    public void Add(TItem item)
    {
        if (!_currentItems.Add(item))
            return;
        if (_original.ContainsKey(item))
            return;
        _added ??= new List<TItem>();
        _added.Add(item);
    }

    public void Remove(TItem item)
    {
        if (!_currentItems.Remove(item))
            return;
        _removed ??= new List<TItem>();
        _removed.Add(item);
    }

    public Diff GetDiff() => new(Added, Updated, Removed);

    private IEnumerable<TDbItem> Added => _added is null 
        ? Enumerable.Empty<TDbItem>() 
        : _added.Select(_toDbItem);

    private IEnumerable<TDbItem> Updated
    {
        get
        {
            foreach (var currentItem in _currentItems)
            {
                if (!_original.TryGetValue(currentItem, out var originalDbItem))
                    continue;
                var currentDbItem = _toDbItem(currentItem);
                if (!currentDbItem.Equals(originalDbItem))
                    yield return currentDbItem;
            }
        }
    }

    private IEnumerable<TDbItem> Removed => _removed is null 
        ? Enumerable.Empty<TDbItem>() 
        : _removed.Select(item => _original[item]);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<TItem> GetEnumerator() => _currentItems.GetEnumerator();

    public bool Contains(TItem item) => _currentItems.Contains(item);

    public bool IsProperSubsetOf(IEnumerable<TItem> other) => _currentItems.IsProperSubsetOf(other);

    public bool IsProperSupersetOf(IEnumerable<TItem> other) => _currentItems.IsProperSupersetOf(other);

    public bool IsSubsetOf(IEnumerable<TItem> other) => _currentItems.IsSubsetOf(other);

    public bool IsSupersetOf(IEnumerable<TItem> other) => _currentItems.IsSupersetOf(other);

    public bool Overlaps(IEnumerable<TItem> other) => _currentItems.Overlaps(other);

    public bool SetEquals(IEnumerable<TItem> other) => _currentItems.SetEquals(other);

    public record Diff(IEnumerable<TDbItem> Added,
        IEnumerable<TDbItem> Updated,
        IEnumerable<TDbItem> Removed);
}