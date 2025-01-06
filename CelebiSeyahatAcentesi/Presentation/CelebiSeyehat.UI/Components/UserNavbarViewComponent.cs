using CelebiSeyehat.Dto.AppUser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CelebiSeyehat.UI.Components
{
    public class UserNavbarViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserNavbarViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = HttpContext.Session.GetString("Token");
            
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage userResponse = await client.GetAsync("https://localhost:7196/api/auth/GetAuthenticatedUser");
            if (!userResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Hata : {userResponse.StatusCode}");
            }
            else
            {
                var userJson = await userResponse.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<AppUserDto>(userJson);
                return View(user);
            }
        }
    }
}
