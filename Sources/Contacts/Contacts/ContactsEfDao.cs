using System.Diagnostics.CodeAnalysis;
using MyCompany.Crm.Contacts.Database;
using MyCompany.Crm.TechnicalStuff.Crud.Ef;

namespace MyCompany.Crm.Contacts
{
    public class ContactsEfDao : EfCrudDao, ContactsCrudOperations
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public ContactsEfDao(ContactsDbContext context) : base(context) { }
    }
}