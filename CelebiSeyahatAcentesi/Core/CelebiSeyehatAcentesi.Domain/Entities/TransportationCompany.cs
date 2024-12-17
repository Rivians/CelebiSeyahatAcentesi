using CelebiSeyahat.Domain.Abstraction;
using CelebiSeyahat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Entities
{
    public class TransportationCompany : BaseEntity
    {
        public string Name { get; set; }
        public TransportationType TransportationType { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
