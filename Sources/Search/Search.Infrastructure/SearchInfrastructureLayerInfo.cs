using System.Reflection;
using System.Runtime.CompilerServices;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Search.Startup")]
[assembly: Layer("Infrastructure")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Search;

public static class SearchInfrastructureLayerInfo
{
    public static Assembly Assembly => typeof(SearchInfrastructureLayerInfo).Assembly;
}