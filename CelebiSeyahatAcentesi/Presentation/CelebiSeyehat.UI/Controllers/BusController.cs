using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Passenger;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Location;
using CelebiSeyehat.UI.ViewModels.Reservation;
using CelebiSeyehat.UI.ViewModels.Trip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json;

namespace CelebiSeyehat.UI.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class BusController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BusController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> SearchBusTrips()
        {
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7196/api/Location/GetLocationList");

            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<LocationListViewModel>>(jsonData);

                //ViewBag.Locations = cityList;
                ViewBag.Locations = locations;

                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchBusTrips(PostTripFilterViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("https://localhost:7196/api/Trip/GetFilteredTrips", model);
            if (responseMessage.IsSuccessStatusCode)
            {
                HttpContext.Session.SetInt32("PassengerCount",model.PassengerCount);    // yolcu sayısını session'da saklıyoruz

                var jsonResult = await responseMessage.Content.ReadAsStringAsync();
                var filteredTrips = JsonConvert.DeserializeObject<List<GetFilteredTripsQueryResponseDto>>(jsonResult);

                // Listeyi base64Encoded'a çevirmek için ilk JSON formatına serilize ediyoruz
                var serializedList = JsonConvert.SerializeObject(filteredTrips);
                var base64EncodedList = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serializedList));

                // filtrelenmiş listeyi base64encoded şeklinde query string yoluyla yolluyoruz.
                return RedirectToAction("FilteredBusTrips","Bus", new { data = base64EncodedList });  
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult FilteredBusTrips(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var base64DecodedList = Convert.FromBase64String(data);
                var json = System.Text.Encoding.UTF8.GetString(base64DecodedList);
                var filteredTrips = JsonConvert.DeserializeObject<List<GetFilteredTripsQueryResponseDto>>(json);

                return View(filteredTrips);
            }

            return View();
        }

        [HttpGet("{tripId}")]
        public async Task<IActionResult> Reservation(string tripId)
        {

			var passengerCount = HttpContext.Session.GetInt32("PassengerCount");
			if (passengerCount == null)
				return RedirectToAction("SearchBusTrips");

			var client = _httpClientFactory.CreateClient();

			// Trip bilgilerini al
			var tripResponse = await client.GetAsync($"https://localhost:7196/api/Trip/{tripId}");
			if (!tripResponse.IsSuccessStatusCode)
				return RedirectToAction("SearchBusTrips");

			var tripJson = await tripResponse.Content.ReadAsStringAsync();
			var trip = JsonConvert.DeserializeObject<TripWithTicketPriceDto>(tripJson);

			// Kullanıcı bilgilerini al
			var userResponse = await client.GetAsync("https://localhost:7196/api/Auth/GetAuthenticatedUser");
			if (!userResponse.IsSuccessStatusCode)
				return RedirectToAction("Login");

			var userJson = await userResponse.Content.ReadAsStringAsync();
			var user = JsonConvert.DeserializeObject<AppUserDto>(userJson);

			// ViewModel'i doldur
			var reservationViewModel = new TransportationReservationViewModel
			{
				Passengers = new List<GetPassengerDto>(), // Yolcuları daha sonra doldurabilirsiniz
				Trip = trip,
				AppUser = user,
				PassengerCount = passengerCount.Value
			};

			return View(reservationViewModel);

















			//        // yolcu sayısının çekilmesi
			//        var passengerCount = HttpContext.Session.GetInt32("PassengerCount");
			//        if (passengerCount == null)
			//            return RedirectToAction("SearchBusTrips");


			//        // user bilgilerinin çekilmesi
			//        var client = _httpClientFactory.CreateClient();
			//        var responseMessage = await client.GetAsync("https://localhost:7196/api/Auth/GetAuthenticatedUser");
			//        if (responseMessage.IsSuccessStatusCode)
			//        {
			//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//            var user = JsonConvert.DeserializeObject<AppUserDto>(jsonData);

			//            if(user == null)
			//            {
			//                return RedirectToAction("Index", "Login");
			//            }


			//            // Trip verilerinin çekilmesi
			//            var responseMessage2 = await client.GetAsync($"https://localhost:7196/api/Trip/{tripId}");
			//            if (!responseMessage2.IsSuccessStatusCode)
			//                return RedirectToAction("SearchBusTrips");

			//var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			//var trip = JsonConvert.DeserializeObject<TripWithTicketPriceDto>(jsonData2);

			//            var reservationViewModel = new TransportationReservationViewModel
			//            {
			//                AppUser = user,
			//                Trip = trip,
			//                Passengers = new List<GetPassengerDto>(),
			//                PassengerCount = passengerCount
			//            };





		}
    }
}
