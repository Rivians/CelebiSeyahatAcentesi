using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string TransportationCompanyId { get; set; }
        public TransportationType TransportationType  { get; set; }
        public string CompanyCoverImageUrl { get; set; }


        public TransportationCompany TransportationCompany { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
