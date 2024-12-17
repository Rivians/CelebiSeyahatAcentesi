using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AppUserId { get; set; }     // customer - appUser 1'e 1 ilişkisinde, bağımlı olan taraf custoemr oldugu için foreign key burada olacak.


        public AppUser AppUser { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Basket Basket { get; set; }
        public LoyaltyPoint LoyaltyPoint { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<HotelReservation> HotelReservations { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
