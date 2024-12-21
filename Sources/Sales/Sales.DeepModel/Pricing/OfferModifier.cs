using System.Diagnostics.Contracts;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddDomainService]
public interface OfferModifier
{
    [Pure]
    Offer ApplyOn(Offer offer);
}

[DddDomainService]
public delegate Offer OfferModifier2(Offer offer);

public class AggregatedModifier(List<OfferModifier> modifiers) : OfferModifier
{
    public Offer ApplyOn(Offer offer) => modifiers
        .Aggregate(offer, (current, modifier) => modifier.ApplyOn(current));
}