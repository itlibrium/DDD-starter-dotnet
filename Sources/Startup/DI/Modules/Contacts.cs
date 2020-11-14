using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Contacts;

namespace MyCompany.Crm.DI.Modules
{
    internal static class ContactsRegistrations
    {
        public static IServiceCollection AddContactsModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<ContactsCrudDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Contacts")));
            services.AddScoped<ContactsCrudOperations, ContactsCrudEfDao>();
            return services;
        }
    }
}