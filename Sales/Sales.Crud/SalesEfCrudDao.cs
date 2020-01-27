using System.Diagnostics.CodeAnalysis;
using TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Sales
{
    public class SalesEfCrudDao : EfCrudDao, SalesCrudDao
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public SalesEfCrudDao(SalesCrudDbContext dbContext) : base(dbContext) { }
    }
}