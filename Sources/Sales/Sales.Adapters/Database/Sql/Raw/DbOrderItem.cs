using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.ECommerce.Sales.Database.Sql.Raw;

[Table("Sales_RawSql.OrderItems")]
public record DbOrderItem
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public string AmountUnit { get; init; }
    public int AmountValue { get; init; }
    public string PriceAgreementType { get; init; }
    public DateTime? PriceAgreementExpiresOn { get; init; }
    public decimal? Price { get; init; }
    public string Currency { get; init; }
}