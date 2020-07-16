using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.Contacts;

namespace MyCompany.Crm.Registrations
{
    internal static class ContactsRegistrations
    {
        public static IServiceCollection RegisterContactsModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<ContactsCrudDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("Contacts")));
            services.AddScoped<ContactsCrudDao, ContactsCrudEfDao>();
            return services;
        }
    }
}