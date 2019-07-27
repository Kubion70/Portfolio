using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Portfolio.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumType)
        {
            string result = enumType.GetType()
                   ?.GetMember(enumType.ToString())
                   ?.FirstOrDefault()
                   ?.GetCustomAttribute<DisplayAttribute>()
                   ?.Name;

            return result ?? enumType.ToString();
        }
    }
}