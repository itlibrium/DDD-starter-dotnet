using System.ComponentModel;
using Nuke.Common.Tooling;

namespace MyCompany.Crm.Nuke
{
    [TypeConverter(typeof(TypeConverter<Environment>))]
    public class Environment : Enumeration
    {
        public static Environment Undefined = new Environment { Value = nameof(Undefined) };
        public static Environment Development = new Environment { Value = nameof(Development) };
        public static Environment Test = new Environment { Value = nameof(Test) };
        public static Environment Production = new Environment { Value = nameof(Production) };

        public static bool EnvironmentIs(Environment environment) => Build.Environment.Equals(environment);
        
        public static implicit operator string(Environment environment) => environment.Value;
    }
}