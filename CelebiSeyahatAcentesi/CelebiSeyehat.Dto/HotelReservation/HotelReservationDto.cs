using CelebiSeyehat.Dto.Customer;
using CelebiSeyehat.Dto.HotelRoom;
using CelebiSeyehat.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.HotelReservation
{
	public class HotelReservationDto
	{
        public string Id { get; set; }
		public string HotelId { get; set; }
		public string CustomerId { get; set; }
        public string HotelRoomId { get; set; }
        public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
		public int? Price { get; set; } // decimal de olabilir
		public int? NumberOfAdults { get; set; }
		public int? NumberOfChildren { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;

        public HotelRoomDto HotelRoom { get; set; }

    }
}
