using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Orders;

public partial class Order
{
    public class Item
    {
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

        public static Item New(ProductAmount productAmount) => new(productAmount, PriceAgreement.Non());

        public void Add(ProductAmount productAmount)
        {
            ProductAmount += productAmount;
            PriceAgreement = PriceAgreement.Non();
        }

        public void ConfirmPrice(Money price) => PriceAgreement = PriceAgreement.Final(price);

        public void ConfirmPrice(Money price, DateTime expiresOn) => 
            PriceAgreement = PriceAgreement.Temporary(price, expiresOn);
    }
}