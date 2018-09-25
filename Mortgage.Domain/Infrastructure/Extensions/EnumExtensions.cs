using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Domain.Infrastructure.Extensions
{
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            var attribute = @enum.GetType().GetField(@enum.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if (attribute == null)
            {
                return @enum.ToString();
            }

            return ((DescriptionAttribute) attribute).Description;
        }

        public static Dictionary<int, string> ToDictionary(this Enum @enum)
        {
           return Enum.GetValues(@enum.GetType()).Cast<object>().ToDictionary(e => (int)e, e => ((Enum)e).GetDescription());
        }
    }
}
