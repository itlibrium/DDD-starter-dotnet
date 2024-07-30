using MyCompany.ECommerce.Sales.Pricing.Discounts;
using MyCompany.ECommerce.Sales.Pricing.SpecialOffers;
using MyCompany.ECommerce.Sales.SalesChannels;
using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.Pricing;

[DddFactory]
public class OfferModifiers(DiscountsRepository discountsRepository)
{
    public async Task<OfferModifier> ChooseFor(OfferRequest offerRequest) =>
        ThreeForTwo.Or(
            EverySecondBoxForHalfPrice.Or(
                CanApplyIndividualSalesConditions(offerRequest)
                    ? await GetIndividualSalesConditions(offerRequest) 
                    : await GetProductLevelDiscounts(offerRequest)));

    private static bool CanApplyIndividualSalesConditions(OfferRequest offerRequest) =>
        offerRequest.SalesChannel == SalesChannel.Wholesale;
        
    private async Task<OfferModifier> GetIndividualSalesConditions(OfferRequest offerRequest)
    {
        var (clientLevelDiscounts, productLevelDiscounts) = await (
            discountsRepository.GetFor(offerRequest.ClientId),
            discountsRepository.GetFor(offerRequest.ProductAmounts));

        return new IndividualSalesConditions(clientLevelDiscounts, productLevelDiscounts);
    }

    private Task<ProductLevelDiscounts> GetProductLevelDiscounts(OfferRequest offerRequest) => 
        discountsRepository.GetFor(offerRequest.ProductAmounts);
}