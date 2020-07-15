using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyCompany.Crm.Contacts
{
    [UsedImplicitly]
    public class ContactsCrudDbContextFactory : IDesignTimeDbContextFactory<ContactsCrudDbContext>
    {
        private const string DatabaseName = "Contacts";
        private const string MigrationsHistoryTable = "__Contacts_Migrations";

        public ContactsCrudDbContext CreateDbContext(string[] args)
        {
            return new ContactsCrudDbContext(new DbContextOptionsBuilder<ContactsCrudDbContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=Contacts;User Id=postgres;Password=password;",
                    sqlOptions => sqlOptions
                        .MigrationsAssembly(typeof(ContactsCrudDbContextFactory).Assembly.FullName)
                        .MigrationsHistoryTable(MigrationsHistoryTable))
                .Options);
        }
    }
}