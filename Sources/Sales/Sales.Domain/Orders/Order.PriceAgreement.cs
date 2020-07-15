using System;
using System.Collections.Immutable;
using System.Linq;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders.PriceChanges;
using MyCompany.Crm.Sales.Pricing;
using MyCompany.Crm.Sales.Products;
using MyCompany.Crm.TechnicalStuff;

namespace MyCompany.Crm.Sales.Orders
{
    public partial class Order
    {
        private readonly struct PriceAgreement : IEquatable<PriceAgreement>
        {
            private readonly ImmutableArray<Quote> _quotes;
            private readonly DateTime _expiresOn;
            public PriceAgreementType Type { get; }
            public DateTime? ExpiresOn => Type == PriceAgreementType.Temporary ? _expiresOn : (DateTime?) null;

            public static PriceAgreement Non() =>
                new PriceAgreement(PriceAgreementType.Non, ImmutableArray<Quote>.Empty, default);

            public static PriceAgreement Temporary(ImmutableArray<Quote> quotes, DateTime expiresOn) =>
                new PriceAgreement(PriceAgreementType.Temporary, quotes, expiresOn);

            public static PriceAgreement Final(ImmutableArray<Quote> quotes) =>
                new PriceAgreement(PriceAgreementType.Final, quotes, default);

            private PriceAgreement(PriceAgreementType type, ImmutableArray<Quote> quotes, DateTime expiresOn)
            {
                _quotes = quotes;
                Type = type;
                _expiresOn = expiresOn;
            }

            public bool CanChangePrices(ImmutableArray<Quote> newQuotes,
                DateTime now,
                PriceChangesPolicy priceChangesPolicy) => Type switch
            {
                PriceAgreementType.Non => true,
                PriceAgreementType.Temporary =>
                ExpiresOn < now || priceChangesPolicy.CanChangePrices(_quotes, newQuotes),
                PriceAgreementType.Final => false,
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, null)
            };

            public bool IsValidOn(DateTime date) => Type switch
            {
                PriceAgreementType.Non => false,
                PriceAgreementType.Temporary => ExpiresOn >= date,
                PriceAgreementType.Final => true,
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, null)
            };

            public Money? GetPrice(ProductAmount productAmount)
            {
                var quote = _quotes.SingleOrDefault(q => q.ProductAmount.Equals(productAmount));
                return quote.Price.IsEmpty ? (Money?) null : quote.Price;
            }

            public bool Equals(PriceAgreement other) =>
                Type == other.Type &&
                _expiresOn.Equals(other._expiresOn) &&
                _quotes.HasSameItemsAs(other._quotes);

            public override bool Equals(object obj) => obj is PriceAgreement other && Equals(other);

            public override int GetHashCode() => new HashCode()
                .CombineWith(_quotes)
                .CombineWith(_expiresOn)
                .CombineWith(Type)
                .ToHashCode();
        }

        public enum PriceAgreementType : byte
        {
            Non,
            Temporary,
            Final
        }
    }
}