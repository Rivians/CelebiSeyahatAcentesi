using CelebiSeyehat.Dto.Token;
using CelebiSeyehat.UI.ViewModels.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CelebiSeyehat.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
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
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (HttpRequestException ex) { 
                ViewBag.Error = $"Error : {ex.Message}";
            }
            
            return View(loginViewModel);
        }
    }
}
