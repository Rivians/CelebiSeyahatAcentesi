using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.HotelType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.HotelRoom
{
    public class HotelRoomDto
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsAvailable { get; set; }
		//public string HotelRoomTypeId { get; set; }


		// buraya roomtypedto verilebilir
		public RoomTypeDto RoomType { get; set; }

		

	}
}
