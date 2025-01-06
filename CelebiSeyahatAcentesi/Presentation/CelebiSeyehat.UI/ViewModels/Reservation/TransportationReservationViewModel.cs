using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Passenger;
using CelebiSeyehat.Dto.Trip;

namespace CelebiSeyehat.UI.ViewModels.Reservation
{
	public class TransportationReservationViewModel
	{
		public List<GetPassengerDto> Passengers { get; set; }
        public TripWithTicketPriceDto Trip { get; set; }
        public AppUserDto AppUser { get; set; }
		public int? PassengerCount { get; set; }
	}
}
