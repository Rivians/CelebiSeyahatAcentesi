using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Customer
{
	public class CustomerDto
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string? AppUserId { get; set; }     
		public string? TcNo { get; set; }
	}
}
