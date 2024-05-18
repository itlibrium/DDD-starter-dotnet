using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MyCompany.ECommerce.Sales.Commons;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Orders;

public partial class Order
{
    [DddValueObject]
    public class PriceAgreement : IEquatable<PriceAgreement>
    {
        public PriceAgreementType Type { get; }
        public Money? Price { get; }
        public DateTime? ExpiresOn { get; }

        public static PriceAgreement Non() => new(PriceAgreementType.Non, null, default);

        public static PriceAgreement Temporary(Money price, DateTime expiresOn) =>
            new(PriceAgreementType.Temporary, price, expiresOn);

        public static PriceAgreement Final(Money price) => new(PriceAgreementType.Final, price, default);

        [JsonConstructor]
        //https://github.com/dotnet/runtime/issues/44428
        public PriceAgreement(PriceAgreementType type, Money? price, DateTime? expiresOn)
        {
            Type = type;
            Price = price;
            ExpiresOn = expiresOn;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "EF")]
        private PriceAgreement() { }

        public bool CanChangePrice() => Type switch
        {
            PriceAgreementType.Non => true,
            PriceAgreementType.Temporary => true,
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

        public bool Equals(PriceAgreement? other) => other is not null &&
                                                     Type == other.Type &&
                                                     Price == other.Price &&
                                                     ExpiresOn == other.ExpiresOn;

        public override bool Equals(object? obj) => obj is PriceAgreement other && Equals(other);

        public override int GetHashCode() => new HashCode()
            .CombineWith(Type)
            .CombineWith(Price)
            .CombineWith(ExpiresOn)
            .ToHashCode();
    }
}