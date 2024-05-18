using System.Diagnostics.CodeAnalysis;
using MyCompany.ECommerce.Contacts.Database;
using MyCompany.ECommerce.TechnicalStuff.Crud.Ef;

namespace MyCompany.ECommerce.Contacts;

[method: SuppressMessage("ReSharper", "SuggestBaseTypeForParameter",
    Justification = "Required by DI container")]
public class ContactsEfDao(ContactsDbContext context) : EfCrudDao(context), ContactsCrudOperations;