using System.Reflection;
using P3Model.Annotations.Technology;

[assembly: Layer("Rest API")]

namespace MyCompany.ECommerce.Sales
{
    public static class SalesRestApiLayerInfo
    {
        public static Assembly Assembly => typeof(SalesRestApiLayerInfo).Assembly;
    }
}