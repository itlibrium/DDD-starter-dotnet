using Microsoft.EntityFrameworkCore;
using MyCompany.ECommerce.Contacts;
using MyCompany.ECommerce.Contacts.Database;

namespace MyCompany.ECommerce.DI.Modules;

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