using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing.SpecialOffers;

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