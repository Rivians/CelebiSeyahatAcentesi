using CelebiSeyehat.Dto.Customer;
using CelebiSeyehat.Dto.Token;
using CelebiSeyehat.Dto.TransportationCompany;
using CelebiSeyehat.Dto.Trip;
using CelebiSeyehat.UI.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CelebiSeyehat.UI.Controllers
{
	public class AdminController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
            var client = _httpClientFactory.CreateClient();

            try
            {
                var response = await client.PostAsJsonAsync("https://localhost:7196/api/Auth/Login", loginViewModel);

                if (response.IsSuccessStatusCode)
                {
                    var jsonDataToken = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenDto>(jsonDataToken);

                    HttpContext.Session.SetString("Token", tokenResponse.AccessToken);  // burada tokenı session içerisine koyuyoruz.
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"Error : {ex.Message}";
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Dashboard()
		{
			return View();
		}

        public async Task<IActionResult> CustomerList()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7196/api/Admin/GetCustomerListWithAll");

            try
            {
				if (reponseMessage.IsSuccessStatusCode)
				{
					var json = await reponseMessage.Content.ReadAsStringAsync();
					var customerList = JsonConvert.DeserializeObject<List<CustomerDto>>(json);

					return View(customerList);
				}
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
				return View();
			}

            return View();
		}

        [HttpGet]
        public async Task<IActionResult> TransportationCompanyList()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7196/api/Admin/GetTransportationCompanyListWithAll");

            try
            {
                if (reponseMessage.IsSuccessStatusCode)
                {
                    var json = await reponseMessage.Content.ReadAsStringAsync();
                    var transportationCompanyList = JsonConvert.DeserializeObject<List<TransportationCompanyDto>>(json);

                    return View(transportationCompanyList);
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
        public async Task<IActionResult> TripList()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7196/api/Admin/GetTripListWithAll");

            try
            {
                if (reponseMessage.IsSuccessStatusCode)
                {
                    var json = await reponseMessage.Content.ReadAsStringAsync();
                    var tripList = JsonConvert.DeserializeObject<List<TripDto>>(json);

                    return View(tripList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

            return View();
        }
    }
}
