using System;

namespace MyCompany.Crm.TechnicalStuff
{
    public static class EnumExtensions
    {
        public static string GetEnumName<T>(this T value) where T : struct, Enum => value.ToString();
        
        public static T ToEnum<T>(this string value) where T: struct, Enum => 
            (T) Enum.Parse(typeof(T), value, true);
    }
}