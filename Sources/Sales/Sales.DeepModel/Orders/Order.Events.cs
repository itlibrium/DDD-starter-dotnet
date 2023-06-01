using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Pricing;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.Orders
{
    public partial class Order
    {
        private readonly List<Event> _newEvents = new();
        public IReadOnlyList<Event> NewEvents => _newEvents.AsReadOnly();

        private void AddAndApply(Event @event)
        {
            @event.Apply(this);
            _newEvents.Add(@event);
        }

        [DomainEvent]
        public interface Event
        {
            void Apply(Order order);
        }

        [DomainEvent]
        public class CreatedFromOffer : Event
        {
            public ImmutableArray<Item> Items { get; }

            public CreatedFromOffer(ImmutableArray<Item> items) => Items = items;

            public void Apply(Order order)
            {
                foreach (var item in Items)
                    order._data.Add(item);
            }
        }

        [DomainEvent]
        public class ProductAmountAdded : Event
        {
            public ProductAmount ProductAmount { get; }

            public ProductAmountAdded(ProductAmount productAmount) => ProductAmount = productAmount;

            public void Apply(Order order) => order.AddToItem(ProductAmount);
        }

        [DomainEvent]
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

        [DomainEvent]
        public class Placed : Event
        {
            public void Apply(Order order) => order._data.IsPlaced = true;
        }
    }
}