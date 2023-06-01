using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MyCompany.Crm.Startup")]
[assembly: InternalsVisibleTo("MyCompany.Crm.Sales.IntegrationTests")]

namespace MyCompany.ECommerce.Sales;

public class SalesDeepModel
{
    public static Assembly Assembly => typeof(SalesDeepModel).Assembly;
}