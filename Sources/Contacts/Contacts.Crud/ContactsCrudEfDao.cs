using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Contacts
{
    public class ContactsCrudEfDao : EfCrudDao, ContactsCrudDao
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public ContactsCrudEfDao(ContactsCrudDbContext context) : base(context) { }
    }
}