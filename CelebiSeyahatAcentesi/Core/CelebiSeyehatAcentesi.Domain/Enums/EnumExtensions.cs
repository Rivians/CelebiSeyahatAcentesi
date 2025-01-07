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

        public static List<string> GetEnumDescriptions<T>() where T : Enum
        {
			return Enum.GetValues(typeof(T)).Cast<T>().Select(v => v.ToString()).ToList();
		}

		private static string GetEnumDescription<T>(T value) where T : Enum
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}
	}
}

	

