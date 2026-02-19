using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace BerkayShop.WebUI.Services
{
	public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public LoginService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

        public string GetUserId
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var user = httpContext?.User;
                // sub varsa onu al, yoksa nameidentifier al
                var userId = user?.FindFirst("sub")?.Value
                          ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("Kullanıcı kimliği alınamadı.");
                return userId;
            }
        }
        //“Login olmuş kullanıcının ID’sini al.”
    }
}
