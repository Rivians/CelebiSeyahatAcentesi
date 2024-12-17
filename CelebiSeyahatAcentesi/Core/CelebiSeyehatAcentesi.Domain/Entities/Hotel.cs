using CelebiSeyahat.Domain.Abstraction;
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
        public string Location { get; set; }


        public ICollection<HotelReservation> Reservations { get; set; }
    }
}
