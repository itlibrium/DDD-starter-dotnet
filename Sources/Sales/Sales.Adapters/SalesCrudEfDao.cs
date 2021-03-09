using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Crud.Ef;

namespace MyCompany.Crm.Sales
{
    public class SalesCrudEfDao : EfCrudDao, SalesCrudOperations
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public SalesCrudEfDao(SalesDbContext context) : base(context) { }
    }
}