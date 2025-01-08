using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Guest;
using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.Passenger;
using CelebiSeyehat.Dto.Trip;

namespace CelebiSeyehat.UI.ViewModels.Reservation
{
	public class HotelReservationViewModel
	{
		public List<GuestDto> Guests { get; set; }
		public HotelDto Hotel { get; set; }
		public HotelReservationDto HotelReservation { get; set; }
		public AppUserDto AppUser { get; set; }
		public int? GuestCount { get; set; }
	}
}
