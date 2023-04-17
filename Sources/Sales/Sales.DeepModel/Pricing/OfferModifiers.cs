using System.Threading.Tasks;
using MyCompany.Crm.Sales.Pricing.Discounts;
using MyCompany.Crm.Sales.Pricing.SpecialOffers;
using MyCompany.Crm.Sales.SalesChannels;
using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.Crm.Sales.Pricing
{
    [DddFactory]
    public class OfferModifiers
    {
        private readonly DiscountsRepository _discountsRepository;

        public OfferModifiers(DiscountsRepository discountsRepository) => _discountsRepository = discountsRepository;

        public async Task<OfferModifier> ChooseFor(OfferRequest offerRequest) =>
            ThreeForTwo.Or(
                EverySecondBoxForHalfPrice.Or(
                    CanApplyIndividualSalesConditions(offerRequest)
                        ? await GetIndividualSalesConditions(offerRequest) 
                        : await GetProductLevelDiscounts(offerRequest)));

        private static bool CanApplyIndividualSalesConditions(OfferRequest offerRequest) =>
            offerRequest.SalesChannel == SalesChannel.Wholesales;
        
        private async Task<OfferModifier> GetIndividualSalesConditions(OfferRequest offerRequest)
        {
            var (clientLevelDiscounts, productLevelDiscounts) = await (
                _discountsRepository.GetFor(offerRequest.ClientId),
                _discountsRepository.GetFor(offerRequest.ProductAmounts));
            return new IndividualSalesConditions(clientLevelDiscounts, productLevelDiscounts);
        }

        private Task<ProductLevelDiscounts> GetProductLevelDiscounts(OfferRequest offerRequest) => 
            _discountsRepository.GetFor(offerRequest.ProductAmounts);
    }
}