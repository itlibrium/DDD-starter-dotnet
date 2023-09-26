using System.Reflection;
using System.Runtime.CompilerServices;
using P3Model.Annotations.Domain;
using P3Model.Annotations.Technology;

[assembly: InternalsVisibleTo("MyCompany.ECommerce.Search.Startup")]
[assembly: Layer("Api")]
[assembly: DomainModel]

namespace MyCompany.ECommerce.Search;

public static class SearchApiLayerInfo
{
    public static Assembly Assembly => typeof(SearchApiLayerInfo).Assembly;
}