using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();

            // enum açıklaması boşsa enum değerini dön, eğer açıklama doluysa enum açıklamasını dön
            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Description;  
        }
    }
}
