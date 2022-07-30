using MyCompany.Crm.TechnicalStuff.Metadata.DDD;

namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    [DddPolicy]
    public class ThreeForTwo : SpecialOffer
    {
        public static ThreeForTwo Or(OfferModifier fallbackModifier) => new(fallbackModifier);

        private ThreeForTwo(OfferModifier fallbackModifier) : base(fallbackModifier)
        {
        }

        public override Offer ApplyOn(Offer offer)
        {
            // implementation coming soon
            return base.ApplyOn(offer);
        }
    }
}