using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.Payments.Requesting;

public readonly struct RequestPayment(Guid requestId, Guid clientId, decimal amount, string currencyCode) : Command
{
    public Guid RequestId { get; } = requestId;
    public Guid ClientId { get; } = clientId;
    public decimal Amount { get; } = amount;
    public string CurrencyCode { get; } = currencyCode;
}