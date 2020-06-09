using System.Diagnostics.CodeAnalysis;
using TechnicalStuff.Crud.DataAccess;

namespace MyCompany.Crm.Contacts
{
    public class ContactsEfCrudDao : EfCrudDao, ContactsCrudDao
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public ContactsEfCrudDao(ContactsCrudDbContext dbContext) : base(dbContext) { }
    }
}