﻿using CelebiSeyehat.Dto.AppUser;
using CelebiSeyehat.Dto.Guest;
using CelebiSeyehat.Dto.Hotel;
using CelebiSeyehat.Dto.HotelReservation;
using CelebiSeyehat.Dto.Passenger;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Hotel;
using CelebiSeyehat.UI.ViewModels.Location;
using CelebiSeyehat.UI.ViewModels.Reservation;
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

					// Listeyi JSON formatına serilize ediyoruz
					var serializedList = JsonConvert.SerializeObject(filteredHotels);

					// Listeyi session'da saklıyoruz
					HttpContext.Session.SetString("FilteredHotels", serializedList);

					return RedirectToAction("FilteredHotels", "Hotel");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return RedirectToAction("SearchHotel");

			}


			return View();
		}

		[HttpGet]
		public async Task<IActionResult> FilteredHotels()
		{
			// Session'dan listeyi geri al
			var serializedList = HttpContext.Session.GetString("FilteredHotels");

			var filteredHotels = JsonConvert.DeserializeObject<List<GetFilteredHotelsQueryResponseDto>>(serializedList);

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


			return View();
		}

		[HttpGet]
		public async Task<IActionResult> HotelDetail(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var reponseMessage = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelById/{id}");

			try
			{
				if (reponseMessage.IsSuccessStatusCode)
				{
					var json = await reponseMessage.Content.ReadAsStringAsync();
					var hotel = JsonConvert.DeserializeObject<HotelDto>(json);
					return View(hotel);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Reservation(string hotelId, string roomId)
		{
			// Misafir sayısını çekiyoruz
			var guestCount = HttpContext.Session.GetInt32("GuestCount");
			if (guestCount == null)
				return RedirectToAction("SearchHotel");

			var client = _httpClientFactory.CreateClient();

			// Hotel bilgilerini çekiyoruz
			var reponseMessageHotel = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelById/{hotelId}");
			var jsonHotel = await reponseMessageHotel.Content.ReadAsStringAsync();
			var hotel = JsonConvert.DeserializeObject<HotelDto>(jsonHotel);


			// HotelReservation bilgileri ---- (chek-in-date / check-out-date / roomType)
			var reponseMessageHotelReservation = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelReservationByRoomId/{hotelId}");
			var jsonHotelReservation = await reponseMessageHotelReservation.Content.ReadAsStringAsync();
			var hotelReservation = JsonConvert.DeserializeObject<HotelReservationDto>(jsonHotelReservation);


			// Kullanıcı bilgilerini alıyoruz
			var token = HttpContext.Session.GetString("Token");
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage userResponse = await client.GetAsync("https://localhost:7196/api/auth/GetAuthenticatedUser");
			if (!userResponse.IsSuccessStatusCode)
				return RedirectToAction("Index", "Login");

			var userJson = await userResponse.Content.ReadAsStringAsync();
			var user = JsonConvert.DeserializeObject<AppUserDto>(userJson);

			// Passengers listesinin içerisini PassengerCount kadar dolduruyoruz
			var guests = new List<GuestDto>();
			for (int i = 0; i < guestCount; i++)
			{
				guests.Add(new GuestDto());
			}

			var hotelReservationViewModel = new HotelReservationViewModel
			{
				Hotel = hotel,
				HotelReservation = hotelReservation,
				AppUser = user,
				GuestCount = guestCount,
				Guests = guests
			};

			ViewBag.RoomId = roomId;
			HttpContext.Session.SetString("RoomId", roomId);

			return View(hotelReservationViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Reservation(HotelReservationViewModel viewModel)
		{
			var client = _httpClientFactory.CreateClient();

			viewModel.AppUser.Customer.TcNo = viewModel.Guests[0].TcNo;
			viewModel.GuestCount = viewModel.Guests.Count();

			// guest kısmı
			var jsonGuests = JsonConvert.SerializeObject(viewModel.Guests);
			HttpContext.Session.SetString("Guests", jsonGuests);

			// hotel kısmı
			var reponseMessage = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelById/{viewModel.Hotel.Id}");
			var json = await reponseMessage.Content.ReadAsStringAsync();
			var hotel = JsonConvert.DeserializeObject<HotelDto>(json);
			viewModel.Hotel = hotel;

			// hotelreservation kısmı
		 	var roomId = HttpContext.Session.GetString("RoomId");

			var reponseMessagehr = await client.GetAsync($"https://localhost:7196/api/Hotel/GetHotelReservationByRoomId/{roomId}");
			var jsonhr = await reponseMessage.Content.ReadAsStringAsync();
			var hotelReservation = JsonConvert.DeserializeObject<HotelReservationDto>(jsonhr);
			viewModel.HotelReservation = hotelReservation;

			var serializedReservationData = JsonConvert.SerializeObject(viewModel);
			//var base64EncodedData = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serializedReservationData));
			HttpContext.Session.SetString("HotelRezervation", serializedReservationData);

			return RedirectToAction("Index", "Payment");
		}

		[HttpGet]
		public async Task<IActionResult> MyReservations()
		{
			return View();
		}
	}
}
