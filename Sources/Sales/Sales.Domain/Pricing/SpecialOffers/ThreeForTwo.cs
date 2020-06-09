namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    public class ThreeForTwo : SpecialOffer
    {
        public static ThreeForTwo Or(OfferModifier fallbackModifier) => new ThreeForTwo(fallbackModifier);

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