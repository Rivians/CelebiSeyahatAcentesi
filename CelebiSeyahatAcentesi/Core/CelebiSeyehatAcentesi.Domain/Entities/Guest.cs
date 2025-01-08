using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
	public class Guest : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public string TcNo { get; set; }
		public string HotelReservationId { get; set; }

		public HotelReservation HotelReservation { get; set; }
	}
}
