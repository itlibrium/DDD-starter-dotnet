using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Clients;
using MyCompany.ECommerce.Sales.Products;
using MyCompany.ECommerce.Sales.SalesChannels;
using MyCompany.ECommerce.TechnicalStuff;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddValueObject]
public readonly struct OfferRequest : IEquatable<OfferRequest>
{
    public ClientId ClientId { get; }
    public SalesChannel SalesChannel { get; }
    public ImmutableArray<ProductAmount> ProductAmounts { get; }

    public static OfferRequest For(ClientId clientId, SalesChannel salesChannel,
        ImmutableArray<ProductAmount> productAmounts) => new(clientId, salesChannel, productAmounts);

    private OfferRequest(ClientId clientId, SalesChannel salesChannel, ImmutableArray<ProductAmount> productAmounts)
    {
        ClientId = clientId;
        SalesChannel = salesChannel;
        ProductAmounts = productAmounts;
    }

    public bool Equals(OfferRequest other) =>
        (ClientId, SalesChannel).Equals((other.ClientId, other.SalesChannel)) &&
        ProductAmounts.SequenceEqual(other.ProductAmounts);
    public override bool Equals(object obj) => obj is OfferRequest other && Equals(other);
    public override int GetHashCode() => (ClientId, SalesChannel).GetHashCode();

    public override string ToString() => $"Offer request for {ClientId.ToString()} and {SalesChannel.ToCode()}";
}