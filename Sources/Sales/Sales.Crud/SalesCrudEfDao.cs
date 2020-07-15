using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Sales
{
    public class SalesCrudEfDao : EfCrudDao, SalesCrudDao
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public SalesCrudEfDao(SalesCrudDbContext context) : base(context) { }
    }
}