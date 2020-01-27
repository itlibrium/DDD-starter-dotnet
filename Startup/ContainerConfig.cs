using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MyCompany.Crm.Contacts;
using MyCompany.Crm.Sales;
using SimpleInjector;

namespace MyCompany.Crm
{
    public static class ContainerConfig
    {
        public static void Apply(Container container, IConfiguration configuration, IHostingEnvironment environment)
        {
            container.Register<ContactsCrudDao, ContactsEfCrudDao>(Lifestyle.Scoped);
            container.Register<SalesCrudDao, SalesEfCrudDao>(Lifestyle.Scoped);
        }
    }
}