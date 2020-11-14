using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    [DddPolicy]
    public class EverySecondBoxForHalfPrice : SpecialOffer
    {
        public static EverySecondBoxForHalfPrice Or(OfferModifier fallbackModifier) => 
            new EverySecondBoxForHalfPrice(fallbackModifier);

        private EverySecondBoxForHalfPrice(OfferModifier fallbackModifier) : base(fallbackModifier)
        {
        }

        public override Offer ApplyOn(Offer offer)
        {
            // implementation coming soon
            return base.ApplyOn(offer);
        }
    }
}