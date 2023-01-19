using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Contacts;
using MyCompany.Crm.Contacts.Database;

namespace MyCompany.Crm.DI.Modules
{
    internal static class ContactsRegistrations
    {
        public static IServiceCollection AddContactsModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<ContactsDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Main"), npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable("__Contacts_Migrations")));
            services.AddScoped<ContactsCrudOperations, ContactsEfDao>();
            return services;
        }
    }
}