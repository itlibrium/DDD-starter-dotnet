using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    [DddDomainService]
    public class SpecialOffer : OfferModifier
    {
        private readonly OfferModifier _fallbackModifier;

        protected SpecialOffer(OfferModifier fallbackModifier) => _fallbackModifier = fallbackModifier;

        public virtual Offer ApplyOn(Offer offer) => _fallbackModifier.ApplyOn(offer);
    }
}