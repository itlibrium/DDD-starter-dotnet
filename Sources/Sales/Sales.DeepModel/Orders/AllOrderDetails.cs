using JetBrains.Annotations;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.Orders;

[ReadModel]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class AllOrderDetails
{
    //TODO: DomainModel + Raw
    public Guid ClientId { get; set; }
    public string CurrencyCode { get; set; }
    public List<OrderItemDetails> Items { get; set; }
        
    // TODO: invoicing details, notes, etc.
}