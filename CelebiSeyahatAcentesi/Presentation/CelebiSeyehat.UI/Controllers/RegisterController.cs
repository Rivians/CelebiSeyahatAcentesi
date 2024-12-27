using CelebiSeyehat.UI.ViewModels.Login;
using CelebiSeyehat.UI.ViewModels.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CelebiSeyehat.UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                registerViewModel.UserName = registerViewModel.Email;
                var response = await client.PostAsJsonAsync("https://localhost:7196/api/Auth/Register", registerViewModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Error = "Kayıt başarısız!";
                }
            }
            catch (HttpRequestException ex) {
                ViewBag.Error = $"Error : {ex.Message}";
            }

            return View(registerViewModel);
        }
    }
}
