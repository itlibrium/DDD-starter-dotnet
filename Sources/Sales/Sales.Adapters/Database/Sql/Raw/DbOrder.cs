using System.ComponentModel.DataAnnotations.Schema;
using MyCompany.ECommerce.TechnicalStuff.Persistence.RepoDb;

namespace MyCompany.ECommerce.Sales.Database.Sql.Raw;

[Table("Sales_RawSql.Orders")]
public record DbOrder(Guid Id, bool IsPlaced, int Version) : DbRootEntity<Guid>;