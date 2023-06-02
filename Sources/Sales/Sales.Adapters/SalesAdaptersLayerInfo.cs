using System.Reflection;
using P3Model.Annotations.Technology;

[assembly: Layer("Adapters")]

namespace MyCompany.ECommerce.Sales
{
    public static class SalesAdaptersLayerInfo
    {
        public static Assembly Assembly => typeof(SalesAdaptersLayerInfo).Assembly;
    }
}