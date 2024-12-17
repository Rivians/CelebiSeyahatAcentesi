using CelebiSeyahat.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public string TransportationCompanyId { get; set; }
        public int Price { get; set; }  // decimal de olabilir
        public string CustomerId { get; set; }


        public Trip Trip { get; set; }
        public Customer Customer { get; set; }    
        public TransportationCompany TransportationCompany { get; set; }
    }
}
