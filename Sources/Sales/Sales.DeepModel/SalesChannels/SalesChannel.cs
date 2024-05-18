using P3Model.Annotations.Domain.DDD;

namespace MyCompany.ECommerce.Sales.SalesChannels
{
    [DddValueObject]
    public enum SalesChannel
    {
        OnlineSale,
        Wholesale
    }
}