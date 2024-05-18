using MyCompany.ECommerce.Sales.Pricing.Discounts;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing
{
    [DddDomainService]
    internal class IndividualSalesConditions : OfferModifier, QuoteModifier
    {
        private readonly ClientLevelDiscounts _clientLevelDiscounts;
        private readonly ProductLevelDiscounts _productLevelDiscounts;

        public IndividualSalesConditions(ClientLevelDiscounts clientLevelDiscounts, 
            ProductLevelDiscounts productLevelDiscounts)
        {
            _clientLevelDiscounts = clientLevelDiscounts;
            _productLevelDiscounts = productLevelDiscounts;
        }

        public Offer ApplyOn(Offer offer) => offer.Apply((QuoteModifier)this);

        public Quote ApplyOn(Quote quote)
        {
            var quote1 =_clientLevelDiscounts.ApplyOn(quote);
            var quote2 = _productLevelDiscounts.ApplyOn(quote);
            return quote1.Price < quote2.Price ? quote1 : quote2;
        }
    }
}