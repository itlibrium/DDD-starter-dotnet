using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.Sales.Database.Sql.EF;
using MyCompany.ECommerce.TechnicalStuff.Crud.Ef;

namespace MyCompany.ECommerce.Sales;

[method: SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
    Justification = "Required by DI container")]
public class SalesCrudEfDao(SalesDbContext context) : EfCrudDao(context), SalesCrudOperations;