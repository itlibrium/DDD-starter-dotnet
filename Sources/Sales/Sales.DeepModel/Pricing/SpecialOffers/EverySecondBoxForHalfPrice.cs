using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing.SpecialOffers
{
    [DddDomainService]
    public class EverySecondBoxForHalfPrice : SpecialOffer
    {
        public static EverySecondBoxForHalfPrice Or(OfferModifier fallbackModifier) => new(fallbackModifier);

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