using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.SpecialOffers
{
    [DddDomainService]
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