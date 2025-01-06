using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class HotelRoom : BaseEntity
    {
        // burada HotelRoomId ayrı olarak zaten baseEntity'den geliyor. Tekrar yazmıyoruz. RoomNumber ise odanın kapı numarısı gibi.
        public string HotelId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public string HotelRoomTypeId { get; set; }


        public Hotel Hotel { get; set; }
        public List<HotelReservation> HotelReservations { get; set; }
        public RoomType RoomType { get; set; }
    }
}
