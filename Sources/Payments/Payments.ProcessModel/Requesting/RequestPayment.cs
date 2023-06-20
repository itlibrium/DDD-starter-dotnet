using System;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using P3Model.Annotations.Domain.DynamicModel;

namespace MyCompany.ECommerce.Payments.Requesting;

[ProcessStepContract]
public readonly struct RequestPayment : Command
{
    public Guid RequestId { get; }
    public Guid ClientId { get; }
    public decimal Amount { get; }
    public string CurrencyCode { get; }

    public RequestPayment(Guid requestId, Guid clientId, decimal amount, string currencyCode)
    {
        RequestId = requestId;
        ClientId = clientId;
        Amount = amount;
        CurrencyCode = currencyCode;
    }
}