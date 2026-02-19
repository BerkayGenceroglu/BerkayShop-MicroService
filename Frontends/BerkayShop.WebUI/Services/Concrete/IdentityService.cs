using BerkayShop.DtoLayer.IdentityDtos.LoginDtos;
using BerkayShop.WebUI.Services.Interfaces;
using BerkayShop.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace BerkayShop.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
	{
		private readonly HttpClient _httpClient;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClientSettings _clientSettings;
		private readonly ServiceApiSettings _serviceApiSettings;
        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var refreshToken = await _httpContextAccessor.HttpContext
		   .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

				// 🔴 EN ÖNEMLİ KONTROL
				if (string.IsNullOrEmpty(refreshToken))
					return false;

				var discovery = await _httpClient.GetDiscoveryDocumentAsync(
					_serviceApiSettings.IdentityServerUrl);

				var request = new RefreshTokenRequest
				{
					ClientId = _clientSettings.BerkayShopManagerClient.ClientId,
					ClientSecret = _clientSettings.BerkayShopManagerClient.ClientSecret,
					Address = discovery.TokenEndpoint,
					RefreshToken = refreshToken
				};

				var token = await _httpClient.RequestRefreshTokenAsync(request);

				// 🔴 Refresh başarısız
				if (token.IsError)
					return false;

				var authResult = await _httpContextAccessor.HttpContext.AuthenticateAsync();

				authResult.Properties.StoreTokens(new List<AuthenticationToken>
				{
					new AuthenticationToken
					{
						Name = OpenIdConnectParameterNames.AccessToken,
						Value = token.AccessToken
					},
					new AuthenticationToken
					{
						Name = OpenIdConnectParameterNames.RefreshToken,
						Value = token.RefreshToken
					},
					new AuthenticationToken
					{
						Name = OpenIdConnectParameterNames.ExpiresIn,
						Value = DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("O")
					}
				});

				await _httpContextAccessor.HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					authResult.Principal,
					authResult.Properties);

				return true;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
		{
			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				Policy = new DiscoveryPolicy
				{
					RequireHttps = false
				}
			});

			var passwordTokenRequest = new PasswordTokenRequest
			{
				ClientId = _clientSettings.BerkayShopManagerClient.ClientId,
				ClientSecret = _clientSettings.BerkayShopManagerClient.ClientSecret,
				UserName = signInDto.Username,
				Password = signInDto.Password,
				Address = discoveryEndPoint.TokenEndpoint
			};

			var token =await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
			var userInfoRequest = new UserInfoRequest
			{
				Token = token.AccessToken,
				Address = discoveryEndPoint.UserInfoEndpoint
			};

			var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims,CookieAuthenticationDefaults.AuthenticationScheme,"name","role");

			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			var authanticationProperties = new AuthenticationProperties();

			authanticationProperties.StoreTokens(new List<AuthenticationToken>()
			{
				new AuthenticationToken
				{
					Name = OpenIdConnectParameterNames.AccessToken,
					Value = token.AccessToken
				},
				new AuthenticationToken
				{
					Name = OpenIdConnectParameterNames.RefreshToken,
					Value = token.RefreshToken
				},
				new AuthenticationToken
				{
					Name = OpenIdConnectParameterNames.ExpiresIn,
					Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
				}
			});
			authanticationProperties.IsPersistent = false;

			await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authanticationProperties);

			return true;
		}
	}
}
