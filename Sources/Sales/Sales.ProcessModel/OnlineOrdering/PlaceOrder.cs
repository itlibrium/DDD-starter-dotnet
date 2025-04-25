using System.Collections.Immutable;
using MyCompany.ECommerce.Sales.Orders;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain;

namespace MyCompany.ECommerce.Sales.OnlineOrdering;

[PublicContract]
[Command]
public readonly struct PlaceOrder(
    Guid clientId,
    string currencyCode,
    ImmutableArray<QuoteDto> quotes,
    InvoicingDetails invoicingDetails)
    : Command
{
    public Guid ClientId { get; } = clientId;
    public string CurrencyCode { get; } = currencyCode;
    public ImmutableArray<QuoteDto> Quotes { get; } = quotes;
    public InvoicingDetails InvoicingDetails { get; } = invoicingDetails;
}