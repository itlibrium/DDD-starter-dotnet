using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class OrderSqlRepository
    {
        private static Order RestoreOrderFrom(OrderData data)
        {
            var priceAgreementType = data.PriceAgreementType.ToDomainModel<Order.PriceAgreementType>();
            return priceAgreementType switch
            {
                Order.PriceAgreementType.Non => RestoreWithNoPriceAgreement(data),
                Order.PriceAgreementType.Temporary => RestoreWithTemporaryPriceAgreement(data),
                Order.PriceAgreementType.Final => RestoreWithFinalPriceAgreement(data),
                _ => throw new ArgumentOutOfRangeException(nameof(priceAgreementType), priceAgreementType, null)
            };
        }

        private static Order RestoreWithNoPriceAgreement(OrderData orderData) => Order.Restore(
            OrderId.From(orderData.Id),
            orderData.Items
                .Select(orderItemData => ProductAmount.Of(ProductId.From(orderItemData.ProductId),
                    Amount.Of(orderItemData.Amount, orderItemData.AmountUnit.ToDomainModel<AmountUnit>())))
                .ToImmutableArray(),
            orderData.IsPlaced);

        private static Order RestoreWithTemporaryPriceAgreement(OrderData orderData)
        {
            if (!orderData.PriceAgreementExpiresOn.HasValue) throw new DomainException();
            return Order.Restore(
                OrderId.From(orderData.Id),
                CreateQuotesFrom(orderData.Items),
                orderData.PriceAgreementExpiresOn.Value,
                orderData.IsPlaced);
        }

        private static Order RestoreWithFinalPriceAgreement(OrderData orderData) => Order.Restore(
            OrderId.From(orderData.Id),
            CreateQuotesFrom(orderData.Items),
            orderData.IsPlaced);

        private static ImmutableArray<Quote> CreateQuotesFrom(IEnumerable<OrderItemData> orderItemsData) =>
            orderItemsData.Select(orderItemData => CreateQuoteFrom(orderItemData)).ToImmutableArray();
        
        private static Quote CreateQuoteFrom(OrderItemData item)
        {
            if (!item.Price.HasValue || item.Currency is null) throw new DomainException();
            return Quote.For(
                ProductAmount.Of(ProductId.From(item.ProductId),
                    Amount.Of(item.Amount, item.AmountUnit.ToDomainModel<AmountUnit>())),
                Money.Of(item.Price.Value, item.Currency.ToDomainModel<Currency>()));
        }
    }
}