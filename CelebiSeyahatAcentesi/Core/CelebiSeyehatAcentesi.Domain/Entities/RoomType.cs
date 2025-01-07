using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class RoomType : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string HotelId { get; set; }


        public Hotel Hotel { get; set; }
        public List<HotelRoom> HotelRooms { get; set; } // o da türüne ait birden fazla oda olabilir. Yani hem 101 hemde 102 numaralı odanın türü Deluxe Room
    }
}
