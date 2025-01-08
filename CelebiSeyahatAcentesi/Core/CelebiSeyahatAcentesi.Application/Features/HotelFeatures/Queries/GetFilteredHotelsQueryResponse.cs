using CelebiSeyahat.Domain.Entities;
using CelebiSeyahat.Domain.Enums;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.HotelRoom;
using CelebiSeyehat.Dto.HotelType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.HotelFeatures.Queries
{
    public class GetFilteredHotelsQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal GuestRating { get; set; }
        public string PensionType { get; set; }
        public List<string> HotelFeatures { get; set; }
        public string CoverImageUrl { get; set; }


        public List<HotelRoomDto> HotelRooms { get; set; }
        public List<HotelReservationDto> Reservations { get; set; }
        public List<RoomTypeDto> RoomTypes { get; set; }


        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Location { get; set; }
        //public double GuestRating { get; set; }
        //public PensionType PensionType { get; set; }
        //public string CoverImageUrl { get; set; }


        //public List<HotelRoom> HotelRooms { get; set; }
        //public List<HotelFeature> HotelFeatures { get; set; }
        //public List<HotelReservation> Reservations { get; set; }
        //public List<RoomType> RoomTypes { get; set; }
    }
}
