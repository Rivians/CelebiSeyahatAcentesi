using CelebiSeyehat.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.AppUser
{
	public class AppUserDto
	{
        public string Id { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public CustomerDto Customer { get; set; }  // Eğer müşteri bilgileri gerekliyse
	}
}
