using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double GuestRating { get; set; }
        public PensionType PensionType { get; set; }
        public string CoverImageUrl { get; set; }


        public List<HotelRoom> HotelRooms { get; set; }
        public List<HotelFeature> HotelFeatures { get; set; }
        public List<HotelReservation> Reservations { get; set; }
        public List<RoomType> RoomTypes { get; set; }
    }
}
