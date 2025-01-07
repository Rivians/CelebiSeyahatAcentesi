using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Hotel;
using CelebiSeyehat.UI.ViewModels.Location;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CelebiSeyehat.UI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HotelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> SearchHotel()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7196/api/Hotel/GetHotelNames");

            // otel adları
            try
            {
                if (reponseMessage.IsSuccessStatusCode)
                {
                    var json = await reponseMessage.Content.ReadAsStringAsync();
                    ViewBag.HotelNames = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // lokasyon apisi için token'ı saklıyoruz
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Login");
            }

            // lokasyona apisine token ile istek atıyoruz
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage2 = await client.GetAsync("https://localhost:7196/api/Location/GetLocationList");  // ------------- BU KISIM 401 DÖNÜYOR -------------

            // şehir adları
            try
            {
                if (reponseMessage.IsSuccessStatusCode)
                {
                    string jsonData = await responseMessage2.Content.ReadAsStringAsync();
                    var locations = JsonConvert.DeserializeObject<List<LocationListViewModel>>(jsonData);

                    ViewBag.Locations = locations;

                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchHotel(PostHotelFilterViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("https://localhost:7196/api/Hotel/GetFilteredHotels", viewModel);
            try
            {
				if (responseMessage.IsSuccessStatusCode)
				{
					HttpContext.Session.SetInt32("GuestCount", viewModel.GuestCount);    // yolcu sayısını session'da saklıyoruz

					var jsonResult = await responseMessage.Content.ReadAsStringAsync();
					var filteredHotels = JsonConvert.DeserializeObject<List<GetFilteredHotelsQueryResponseDto>>(jsonResult);

					// Listeyi base64Encoded'a çevirmek için ilk JSON formatına serilize ediyoruz
					var serializedList = JsonConvert.SerializeObject(filteredHotels);
					var base64EncodedList = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serializedList));

					// filtrelenmiş listeyi base64encoded şeklinde query string yoluyla yolluyoruz.
					return RedirectToAction("FilteredHotels", "Hotel", new { data = base64EncodedList });
				}
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("SearchHotel");

			}


            return View();
        }

		[HttpGet]
		public async Task<IActionResult> FilteredHotels(string data)
		{
			if (!string.IsNullOrEmpty(data))
			{
				var base64DecodedList = Convert.FromBase64String(data);
				var json = System.Text.Encoding.UTF8.GetString(base64DecodedList);
				var filteredHotels = JsonConvert.DeserializeObject<List<GetFilteredHotelsQueryResponseDto>>(json);

				// sadece seçilmiş lokasyonu viewbag'de tutuyoruz.
				var location = filteredHotels.FirstOrDefault().Location;
				ViewBag.SelectedLocation = location;

                var client = _httpClientFactory.CreateClient();
				// lokasyon apisi için token'ı saklıyoruz
				var token = HttpContext.Session.GetString("Token");
				if (string.IsNullOrEmpty(token))
				{
					return RedirectToAction("Index", "Login");
				}

				// lokasyon listesi
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage responseMessageLocations = await client.GetAsync("https://localhost:7196/api/Location/GetLocationList");  

				try
				{
					if (responseMessageLocations.IsSuccessStatusCode)
					{
						string jsonData = await responseMessageLocations.Content.ReadAsStringAsync();
						var locations = JsonConvert.DeserializeObject<List<LocationListViewModel>>(jsonData);

						ViewBag.Locations = locations;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return View();
				}

				// otel özellik listesi
				HttpResponseMessage responseMessageFeatures = await client.GetAsync("https://localhost:7196/api/Hotel/GetHotelFeatures");  
				try
				{
					if (responseMessageFeatures.IsSuccessStatusCode)
					{
						string jsonData = await responseMessageFeatures.Content.ReadAsStringAsync();
						var features = JsonConvert.DeserializeObject<List<HotelFeaturesViewModel>>(jsonData);

						ViewBag.HotelFeatures = features;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return View();
				}

				// otel pansiyon türü listesi
				HttpResponseMessage responseMessagePensionTypes = await client.GetAsync("https://localhost:7196/api/Hotel/GetHotelPensionTypes");
				try
				{
					if (responseMessagePensionTypes.IsSuccessStatusCode)
					{
						string jsonData = await responseMessagePensionTypes.Content.ReadAsStringAsync();
						var pensionTypes = JsonConvert.DeserializeObject<List<HotelPensionTypeViewModel>>(jsonData);

						ViewBag.HotelPensionTypes = pensionTypes;

						return View(filteredHotels);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return View();
				}
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> HotelDeail(string id)
		{
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelById/{id}");

            try
            {
                if (reponseMessage.IsSuccessStatusCode)
                {
                    var json = await reponseMessage.Content.ReadAsStringAsync();
                    ViewBag.HotelNames = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View();
		}



		//public IActionResult test()
		//{
		//    return View();
		//}
	}
}
