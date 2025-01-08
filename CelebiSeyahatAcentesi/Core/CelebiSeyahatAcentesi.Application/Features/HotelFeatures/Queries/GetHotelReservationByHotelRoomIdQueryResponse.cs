using CelebiSeyahat.Domain.Entities;
using CelebiSeyehat.Dto.HotelRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
	public class GetHotelReservationByHotelRoomIdQueryResponse
	{
        public string Id { get; set; }
        public string HotelRoomId { get; set; }
		public string? CustomerId { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
		public int Price { get; set; } // decimal de olabilir
		public int? NumberOfAdults { get; set; }
		public int? NumberOfChildren { get; set; }


		public HotelRoomDto HotelRoom { get; set; }

	}
}
