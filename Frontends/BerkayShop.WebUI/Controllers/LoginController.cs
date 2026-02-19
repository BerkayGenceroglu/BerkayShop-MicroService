using BerkayShop.DtoLayer.IdentityDtos.LoginDtos;
using BerkayShop.WebUI.Models;
using BerkayShop.WebUI.Services;
using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace BerkayShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		private readonly IIdentityService _identityService;
		public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
			_identityService = identityService;
		}

		[HttpGet]
		public IActionResult LoginPage()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> LoginPage(LoginBerkayShopDto dto)
		{
            return RedirectToAction("Index", "User");
		}

		[HttpGet]
		public async Task<IActionResult> SignIn()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "Can123";
            signInDto.Password = "123456Aa*";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }
    }
}
