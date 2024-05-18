using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.Metadata;

namespace MyCompany.ECommerce.Sales.Orders;

[DataStructure]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class AllOrderDetails
{
    //TODO: DomainModel + Raw
    public Guid ClientId { get; set; }
    public string CurrencyCode { get; set; }
    public List<OrderItemDetails> Items { get; set; }
        
    // TODO: invoicing details, notes, etc.
}