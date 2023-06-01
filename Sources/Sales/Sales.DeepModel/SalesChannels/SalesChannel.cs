using P3Model.Annotations.Domain.StaticModel.DDD;

namespace MyCompany.ECommerce.Sales.SalesChannels
{
    [DddValueObject]
    public enum SalesChannel
    {
        OnlineSale,
        Wholesale
    }
}