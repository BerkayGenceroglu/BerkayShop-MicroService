
using BerkayShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;

namespace BerkayShop.WebUI.Handlers
{
    //API’ye giden her isteğe Access Token eklemek,
    //Süresi bittiyse Refresh Token ile yenileyip tekrar deneme
    public class ResourceOwnerPasswordTokenHandler:DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = _httpContextAccessor.HttpContext;

            var accessToken = await context.GetTokenAsync(
                OpenIdConnectParameterNames.AccessToken);

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await base.SendAsync(request, cancellationToken);

            // 🔐 SADECE AUTH HATASI
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshed = await _identityService.GetRefreshToken();

                // ❌ Refresh başarısız → Login
                if (!refreshed)
                {
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.Redirect("/Login/Index");
                    return response;
                }

                // ✅ Yeni token ile tekrar dene
                var newAccessToken = await context.GetTokenAsync(
                    OpenIdConnectParameterNames.AccessToken);

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", newAccessToken);

                return await base.SendAsync(request, cancellationToken);
            }
            return response;
         }
    }
}
//Her API isteğinde access token ekle → 401 gelirse refresh token ile yenile → tekrar dene → hâlâ olmazsa kullanıcıyı düşür
//✅ Mevcut token'ı al ve isteğe ekle
//📤 İsteği gönder
//❌ 401 gelirse → Token yenile
//🔄 Yeni token ile tekrar dene
//❌ Hala 401 ise → Hata yönetimi