using CelebiSeyahat.Application.Services;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Services
{
	public class EnumService : IEnumService
	{
		public List<string> GetPensionTypes()
		{
			return EnumExtensions.GetEnumDescriptions<PensionType>();
		}
	}
}
