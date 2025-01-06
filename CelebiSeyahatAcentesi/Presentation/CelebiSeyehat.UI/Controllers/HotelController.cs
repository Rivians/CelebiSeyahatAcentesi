using CelebiSeyehat.Dto.Trip;
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

        
        //public IActionResult test()
        //{
        //    return View();
        //}
    }
}
