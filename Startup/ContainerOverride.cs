using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace MyCompany.Crm
{
    public interface ContainerOverride
    {
        void Apply(Container container, IConfiguration configuration, IHostingEnvironment environment);
    }
}