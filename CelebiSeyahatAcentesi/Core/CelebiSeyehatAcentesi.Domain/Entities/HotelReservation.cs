using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    // bu entity bir ticket'a denk geliyor gibi düşünülebilir. 
    public class HotelReservation : BaseEntity
    {
        public string HotelRoomId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Price { get; set; } // decimal de olabilir
        public int? NumberOfAdults { get; set; }
        public int? NumberOfChildren { get; set; }


        public HotelRoom HotelRoom { get; set; }
        public Customer Customer { get; set; }
		public Payment Payment { get; set; }
	}
}
