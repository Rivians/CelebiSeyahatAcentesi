using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Ticket
{
	public class TicketDto
	{
        public string Id { get; set; }
        public string? Departure { get; set; }
		public string? Destination { get; set; }
		public DateTime? DepartureDate { get; set; }
		public string? TransportationCompanyId { get; set; }
		public int? Price { get; set; }  // decimal de olabilir
		public string? CustomerId { get; set; }
		public string? TripId { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
