using SimpleInjector.Integration.ServiceCollection;

namespace MyCompany.Crm
{
    public static class SimpleInjectorExtensions
    {
        public static SimpleInjectorAddOptions DisableAutoCrossWire(this SimpleInjectorAddOptions options)
        {
            options.AutoCrossWireFrameworkComponents = false;
            return options;
        }
    }
}