using System.Linq;
using MyCompany.Crm.Sales.Pricing.Discounts;

namespace MyCompany.Crm.Sales.Pricing
{
    internal class IndividualSalesConditions : OfferModifier
    {
        private readonly ClientLevelDiscounts _clientLevelDiscounts;
        private readonly ProductLevelDiscounts _productLevelDiscounts;

        public IndividualSalesConditions(ClientLevelDiscounts clientLevelDiscounts, 
            ProductLevelDiscounts productLevelDiscounts)
        {
            _clientLevelDiscounts = clientLevelDiscounts;
            _productLevelDiscounts = productLevelDiscounts;
        }

        public Offer ApplyOn(Offer offer) => Offer.FromQuotes(offer.Quotes.Select(RecalculateQuote));

        private Quote RecalculateQuote(Quote quote)
        {
            var quote1 =_clientLevelDiscounts.RecalculateQuote(quote);
            var quote2 = _productLevelDiscounts.RecalculateQuote(quote);
            return quote1.Price < quote2.Price ? quote1 : quote2;
        }
    }
}