using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    private readonly List<Event> _newEvents = new();
    public IReadOnlyList<Event> NewEvents => _newEvents.AsReadOnly();

    private void AddAndApply(Event @event)
    {
        @event.Apply(this);
        _newEvents.Add(@event);
    }

    public interface Event
    {
        void Apply(Order order);
    }

    [Event]
    public class CreatedFromOffer(ImmutableArray<Item> items) : Event
    {
        public ImmutableArray<Item> Items { get; } = items;

        public void Apply(Order order)
        {
            foreach (var item in Items)
                order._data.Add(item);
        }
    }

    [Event]
    public class ProductAmountAdded(ProductAmount productAmount) : Event
    {
        public ProductAmount ProductAmount { get; } = productAmount;

        public void Apply(Order order) => order.AddToItem(ProductAmount);
    }

    [Event]
    public class PricesConfirmed : Event
    {
        public ImmutableArray<Quote> Quotes { get; }
        public PriceAgreementType AgreementType { get; }
        public DateTime? AgreementExpiresOn { get; }

        public PricesConfirmed(ImmutableArray<Quote> quotes, PriceAgreementType agreementType, 
            DateTime? agreementExpiresOn)
        {
            switch (agreementType)
            {
                case PriceAgreementType.Non:
                    throw new ArgumentException();
                case PriceAgreementType.Temporary:
                    if (!agreementExpiresOn.HasValue)
                        throw new ArgumentException();
                    break;
                case PriceAgreementType.Final:
                    if (agreementExpiresOn.HasValue)
                        throw new ArgumentException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(agreementType), agreementType, null);
            }
            Quotes = quotes;
            AgreementType = agreementType;
            AgreementExpiresOn = agreementExpiresOn;
        }

        public void Apply(Order order) => order.ApplyPriceAgreements(Quotes, AgreementType, AgreementExpiresOn);
    }

    [Event]
    public class Placed : Event
    {
        public void Apply(Order order) => order._data.IsPlaced = true;
    }
}