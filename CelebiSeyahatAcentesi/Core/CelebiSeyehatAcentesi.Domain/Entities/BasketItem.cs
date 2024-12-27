using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string? TicketId { get; set; }
        public string? HotelReservationId { get; set; }
        public int Price { get; set; } // decimal de olabilir
        public int Quantity { get; set; }


        public Basket Basket { get; set; }  
        public Ticket Ticket { get; set; }  // burada ilişkiyi belirttik fakat Ticket tarafında basketItem ile alakalı bir ilişki kurmadık. Çünkü tek yönlü bir ilişki istiyoruz
        public HotelReservation HotelReservation { get; set; } // burada ilişkiyi belirttik fakat HotelReservation tarafında basketItem ile alakalı bir ilişki kurmadık. Çünkü tek yönlü bir ilişki istiyoruz
    }
}
