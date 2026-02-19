using BerkayShop.DtoLayer.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BerkayShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterPage(CreateRegisterDto createRegisterDto)
        {
            if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
            {
                var client = _httpClientFactory.CreateClient();
			    var jsondata = JsonConvert.SerializeObject(createRegisterDto);
			    StringContent stringContent = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
			    var responseMessage = await client.PostAsync("http://localhost:5001/api/Register", stringContent);
			    if (responseMessage.IsSuccessStatusCode)
			    {
				    return RedirectToAction("LoginPage", "Login");
			    }
            }
			return View();
		}
    }
}
