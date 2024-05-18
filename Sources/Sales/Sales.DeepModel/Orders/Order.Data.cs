using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    private readonly Data _data;

    private Order(Data data) => _data = data;

    public static Order RestoreFrom(Data data) => new(data);

    public interface Data : IEquatable<Data>
    {
        OrderId Id { get; }
        Money MaxTotalCost { get; }
        bool IsPlaced { get; set; }
        IReadOnlyCollection<Item> Items { get; }
        
        public bool TryGetItem(ProductUnit productUnit, [NotNullWhen(true)] out Item? item)
        {
            item = Items.SingleOrDefault(i => i.ProductAmount.ProductUnit.Equals(productUnit));
            return item != null;
        }

        void Add(Item item);
        void Remove(Item item);

        bool IEquatable<Data>.Equals(Data? other) =>
            other is not null &&
            Id.Equals(other.Id) &&
            IsPlaced == other.IsPlaced &&
            Items.All(item => other.Items.Contains(item));
    }
}