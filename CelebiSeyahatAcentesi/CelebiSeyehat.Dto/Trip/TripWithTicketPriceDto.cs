using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyehat.Dto.Trip
{
	public class TripWithTicketPriceDto
	{
		public string Id { get; set; }
		public string Departure { get; set; }
		public string Destination { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ArrivalDate { get; set; }
		public int TotalSeats { get; set; }
		public int AvailableSeats { get; set; }
		public string TransportationCompanyId { get; set; }
		public string TransportationType { get; set; }
		public string CompanyCoverImageUrl { get; set; }
		public int? TicketPrice { get; set; }
	}
}
