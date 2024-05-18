using MyCompany.ECommerce.Sales.Pricing.Discounts;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddDomainService]
internal class IndividualSalesConditions(
    ClientLevelDiscounts clientLevelDiscounts,
    ProductLevelDiscounts productLevelDiscounts)
    : OfferModifier, QuoteModifier
{
    public Offer ApplyOn(Offer offer) => offer.Apply((QuoteModifier)this);

    public Quote ApplyOn(Quote quote)
    {
        var quote1 =clientLevelDiscounts.ApplyOn(quote);
        var quote2 = productLevelDiscounts.ApplyOn(quote);
        return quote1.Price < quote2.Price ? quote1 : quote2;
    }
}