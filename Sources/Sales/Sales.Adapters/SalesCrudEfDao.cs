using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.Sales.Database.Sql.EF;
using MyCompany.ECommerce.TechnicalStuff.Crud.Ef;

namespace MyCompany.ECommerce.Sales
{
    public class SalesCrudEfDao : EfCrudDao, SalesCrudOperations
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public SalesCrudEfDao(SalesDbContext context) : base(context) { }
    }
}