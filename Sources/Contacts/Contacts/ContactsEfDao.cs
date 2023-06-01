using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.Contacts.Database;
using MyCompany.ECommerce.TechnicalStuff.Crud.Ef;

namespace MyCompany.ECommerce.Contacts
{
    public class ContactsEfDao : EfCrudDao, ContactsCrudOperations
    {
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
            Justification = "Required by DI container")]
        public ContactsEfDao(ContactsDbContext context) : base(context) { }
    }
}