using CelebiSeyehat.UI.ViewModels.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                    var result = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Giriş başarılı!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Hatalı giriş!";
                }
            }
            catch (HttpRequestException ex) { 
                ViewBag.Error = $"Error : {ex.Message}";
            }
            
            return View(loginViewModel);
        }
    }
}
