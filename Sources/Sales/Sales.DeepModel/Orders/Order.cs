using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Orders.PriceChanges;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

[DddAggregate]
[ShortDescription("*An order is a request for products.* It is placed by a customer and contains " +
                  "a list of products with their amounts. The order is placed when the customer " +
                  "confirms the prices of the products.")]
public partial class Order : IEquatable<Order>, DataEquals<Order>
{
    public OrderId Id => _data.Id;

    public IEnumerable<ProductAmount> ProductAmounts => _data.Items.Select(item => item.ProductAmount);

    public void Add(ProductAmount productAmount)
    {
            if (_data.IsPlaced)
                throw new DomainError();
            AddAndApply(new ProductAmountAdded(productAmount));

            // Version without events:
            // AddToItem(productAmount);
        }

    private void AddToItem(ProductAmount productAmount)
    {
            var productUnit = productAmount.ProductUnit;
            if (_data.TryGetItem(productUnit, out var item))
                item.Add(productAmount);
            else
                _data.Add(Item.For(productAmount));
    }

    public void ConfirmPrices(Offer offer, PriceChangesPolicy priceChangesPolicy) =>
        ConfirmPrices(offer.Quotes, priceChangesPolicy, PriceAgreementType.Final, default);

    public void ConfirmPrices(Offer offer, PriceChangesPolicy priceChangesPolicy, DateTime agreementExpiresOn) =>
        ConfirmPrices(offer.Quotes, priceChangesPolicy, PriceAgreementType.Temporary, agreementExpiresOn);

    private void ConfirmPrices(ImmutableArray<Quote> newQuotes,
        PriceChangesPolicy priceChangesPolicy,
        PriceAgreementType agreementType,
        DateTime? agreementExpiresOn)
    {
        if (_data.IsPlaced)
            throw new DomainError();
        if (!newQuotes.All(quote => HasMatchingItemFor(quote.ProductAmount)))
            throw new DomainError();
        if (!newQuotes.All(quote => CanChangePriceFor(quote.ProductAmount)))
            throw new DomainError();
        var oldQuotes = _data.Items
            .Where(i => i.PriceAgreement.Type != PriceAgreementType.Non)
            .Select(i => Quote.For(i.ProductAmount, i.PriceAgreement.Price!))
            .ToImmutableArray();
        if (!priceChangesPolicy.CanChangePrices(oldQuotes, newQuotes))
            throw new DomainError();
        AddAndApply(new PricesConfirmed(newQuotes, agreementType, agreementExpiresOn));

        // Version without events:
        // ApplyPriceAgreements(newQuotes, agreementType, agreementExpiresOn);
    }

    private bool HasMatchingItemFor(ProductAmount productAmount) =>
        _data.TryGetItem(productAmount.ProductUnit, out var item) &&
        item.ProductAmount.Equals(productAmount);

    private bool CanChangePriceFor(ProductAmount productAmount) =>
        _data.TryGetItem(productAmount.ProductUnit, out var item) &&
        item.PriceAgreement.CanChangePrice();

    private void ApplyPriceAgreements(ImmutableArray<Quote> quotes, PriceAgreementType agreementType,
        DateTime? agreementExpiresOn)
    {
        foreach (var quote in quotes)
        {
            var productUnit = quote.ProductAmount.ProductUnit;
            if (!_data.TryGetItem(productUnit, out var item))
                throw new CorruptedDataError();
            switch (agreementType)
            {
                case PriceAgreementType.Temporary:
                    item.ConfirmPrice(quote.Price, agreementExpiresOn!.Value);
                    break;
                case PriceAgreementType.Final:
                    item.ConfirmPrice(quote.Price);
                    break;
                case PriceAgreementType.Non:
                    throw new CorruptedDataError();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void Place(DateTime now)
    {
        if (_data.IsPlaced) return;
        if (!AllItemsHaveValidPriceAgreementOn(now)) throw new DomainError();
        AddAndApply(new Placed());

        // Version without events:
        // _isPlaced = true;
    }

    private bool AllItemsHaveValidPriceAgreementOn(DateTime date) =>
        _data.Items.All(item => item.PriceAgreement.IsValidOn(date));

    public override bool Equals(object? obj) => obj is Order other && Equals(other);
    public bool Equals(Order? other) => other is not null && Id.Equals(other.Id);
    public override int GetHashCode() => Id.GetHashCode();

    public bool HasSameDataAs(Order other) => _data.Equals(other._data);
}