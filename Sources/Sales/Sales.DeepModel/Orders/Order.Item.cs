using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.Sales.Products;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    public class Item : IEquatable<Item>
    {
        public ProductUnit Id => ProductAmount.ProductUnit;
        public ProductAmount ProductAmount { get; private set; }
        public PriceAgreement PriceAgreement { get; private set; }

        [JsonConstructor]
        public Item(ProductAmount productAmount, PriceAgreement priceAgreement)
        {
            ProductAmount = productAmount;
            PriceAgreement = priceAgreement;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "EF")]
        private Item() { }

        public static Item For(ProductAmount productAmount) => new(productAmount, PriceAgreement.Non());

        public void Add(ProductAmount productAmount)
        {
            ProductAmount += productAmount;
            PriceAgreement = PriceAgreement.Non();
        }

        public void ConfirmPrice(Money price) => PriceAgreement = PriceAgreement.Final(price);

        public void ConfirmPrice(Money price, DateTime expiresOn) =>
            PriceAgreement = PriceAgreement.Temporary(price, expiresOn);

        public bool Equals(Item? other) => other is not null && Id.Equals(other.Id);

        public bool HasSameDataAs(Item other) =>
            ProductAmount.Equals(other.ProductAmount) &&
            PriceAgreement.Equals(other.PriceAgreement);
    }
}