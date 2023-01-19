using System;
using System.ComponentModel.DataAnnotations.Schema;
using MyCompany.Crm.TechnicalStuff.Persistence.RepoDb;

namespace MyCompany.Crm.Sales.Database.Sql.Raw;

[Table("Sales_RawSql.Orders")]
public record DbOrder(Guid Id, bool IsPlaced, int Version) : DbRootEntity<Guid>;