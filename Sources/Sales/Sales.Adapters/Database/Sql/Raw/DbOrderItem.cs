using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany.ECommerce.Sales.Database.Sql.Raw;

[Table("Sales_RawSql.OrderItems")]
public record DbOrderItem(Guid OrderId, Guid ProductId, string AmountUnit, int AmountValue, string PriceAgreementType, DateTime? PriceAgreementExpiresOn, decimal? Price, string Currency);
