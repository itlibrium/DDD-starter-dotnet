using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    [DddPolicy]
    public class SpecialOffer : OfferModifier
    {
        private readonly OfferModifier _fallbackModifier;

        protected SpecialOffer(OfferModifier fallbackModifier) => _fallbackModifier = fallbackModifier;

        public virtual Offer ApplyOn(Offer offer) => _fallbackModifier.ApplyOn(offer);
    }
}