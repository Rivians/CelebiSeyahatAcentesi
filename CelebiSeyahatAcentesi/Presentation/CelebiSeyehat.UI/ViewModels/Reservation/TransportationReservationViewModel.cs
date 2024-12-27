using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Passenger;
using CelebiSeyehat.Dto.Trip;

namespace CelebiSeyehat.UI.ViewModels.Reservation
{
	public class TransportationReservationViewModel
	{
		//// Trip bilgileri
		//public int TripId { get; set; } // Seçilen seferin ID'si
		//public string Departure { get; set; } // Kalkış noktası
		//public string Destination { get; set; } // Varış noktası
		//public DateTime DepartureDate { get; set; } // Kalkış tarihi
		//public decimal TicketPrice { get; set; } // Bilet fiyatı


		//// Giriş yapan kullanıcının bilgileri
		//public string CustomerName { get; set; }
		//public string CustomerSurname { get; set; }
		//public string CustomerEmail { get; set; }
		//public string CustomerPhoneNumber { get; set; }


  //      // Yolcu listesi
  //      public List<GetPassengerDto> Passengers { get; set; }







		public List<GetPassengerDto> Passengers { get; set; }
        public TripWithTicketPriceDto Trip { get; set; }
        public AppUserDto AppUser { get; set; }
		public int? PassengerCount { get; set; }


	}
}
