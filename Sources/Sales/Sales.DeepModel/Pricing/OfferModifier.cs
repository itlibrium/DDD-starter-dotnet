using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing
{
    [DddDomainService]
    public interface OfferModifier
    {
        [Pure]
        Offer ApplyOn(Offer offer);
    }

    [DddDomainService]
    public delegate Offer OfferModifier2(Offer offer);

    public class AggregatedModifier : OfferModifier
    {
        private readonly List<OfferModifier> _modifiers;
        
        public AggregatedModifier(List<OfferModifier> modifiers) => _modifiers = modifiers;

        public Offer ApplyOn(Offer offer) => _modifiers
            .Aggregate(offer, (current, modifier) => modifier.ApplyOn(current));
    }
}