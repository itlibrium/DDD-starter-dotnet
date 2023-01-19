using Nuke.Common.Tooling;

namespace MyCompany.Crm.Nuke.Helpers
{
    public static class EnumerationExtensions
    {
        public static string ValueToLower(this Enumeration enumeration) => enumeration.ToString().ToLower();
    }
}