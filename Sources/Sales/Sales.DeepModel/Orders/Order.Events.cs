using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        private readonly List<Event> _newEvents = new();
        public IReadOnlyList<Event> NewEvents => _newEvents.AsReadOnly();

        public static Order RestoreFrom(OrderId id, IEnumerable<Event> events)
        {
            var order = New(id);
            foreach (var @event in events)
                @event.Apply(order);
            return order;
        }

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
            public ImmutableArray<PriceConfirmation> PriceConfirmations { get; }

            public CreatedFromOffer(ImmutableArray<PriceConfirmation> priceConfirmations) => 
                PriceConfirmations = priceConfirmations;

            public void Apply(Order order)
            {
                var quotes = new List<Quote>();
                foreach (var priceConfirmation in PriceConfirmations)
                {
                    var productId = ProductId.From(priceConfirmation.ProductId);
                    var amount = Amount.Of(
                        priceConfirmation.Amount,
                        priceConfirmation.AmountUnit.ToDomainModel<AmountUnit>());
                    order._items.Add(
                        ProductUnit.Of(
                            productId,
                            priceConfirmation.AmountUnit.ToDomainModel<AmountUnit>()),
                        amount);
                    quotes.Add(Quote.For(
                        ProductAmount.Of(productId, amount),
                        Money.Of(
                            priceConfirmation.Price,
                            priceConfirmation.Currency.ToDomainModel<Currency>())));
                }
                order._priceAgreement = PriceAgreement.Final(quotes.ToImmutableArray());
            }
        }

        [DomainEvent]
        public class ProductAmountAdded : Event
        {
            public Guid ProductId { get; }
            public string AmountUnit { get; }
            public int Amount { get; }

            public ProductAmountAdded(Guid productId, string amountUnit, int amount)
            {
                ProductId = productId;
                AmountUnit = amountUnit;
                Amount = amount;
            }

            public void Apply(Order order)
            {
                var amountUnit = AmountUnit.ToDomainModel<AmountUnit>();
                order.AddItem(
                    ProductUnit.Of(
                        Products.ProductId.From(ProductId),
                        amountUnit),
                    Products.Amount.Of(
                        Amount,
                        amountUnit));
            }
        }

        [DomainEvent]
        public class PricesConfirmed : Event
        {
            public DateTime PriceAgreementExpiresOn { get; }
            public ImmutableArray<PriceConfirmation> PriceConfirmations { get; }

            public PricesConfirmed(DateTime priceAgreementExpiresOn,
                ImmutableArray<PriceConfirmation> priceConfirmations)
            {
                PriceAgreementExpiresOn = priceAgreementExpiresOn;
                PriceConfirmations = priceConfirmations;
            }

            public void Apply(Order order)
            {
                var quotes = PriceConfirmations
                    .Select(confirmation => Quote.For(
                        ProductAmount.Of(
                            ProductId.From(confirmation.ProductId),
                            Amount.Of(
                                confirmation.Amount,
                                confirmation.AmountUnit.ToDomainModel<AmountUnit>())),
                        Money.Of(
                            confirmation.Price,
                            confirmation.Currency.ToDomainModel<Currency>())))
                    .ToImmutableArray();
                order._priceAgreement = PriceAgreement.Temporary(quotes, PriceAgreementExpiresOn);
            }
        }

        public class PriceConfirmation
        {
            public Guid ProductId { get; }
            public int Amount { get; }
            public string AmountUnit { get; }
            public decimal Price { get; }
            public string Currency { get; }

            public PriceConfirmation(Guid productId, int amount, string amountUnit, decimal price, string currency)
            {
                ProductId = productId;
                Amount = amount;
                AmountUnit = amountUnit;
                Price = price;
                Currency = currency;
            }
        }

        [DomainEvent]
        public class Placed : Event
        {
            public void Apply(Order order) => order._isPlaced = true;
        }
    }
}