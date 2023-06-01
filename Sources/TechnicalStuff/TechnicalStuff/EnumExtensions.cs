using System;

namespace MyCompany.ECommerce.TechnicalStuff
{
    public static class EnumExtensions
    {
        public static string ToCode<T>(this T value) where T : struct, Enum => value.ToString();
        
        public static T ToDomainModel<T>(this string value) where T: struct, Enum => 
            (T) Enum.Parse(typeof(T), value, true);
    }
}