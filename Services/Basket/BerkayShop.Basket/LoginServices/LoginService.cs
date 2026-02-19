namespace BerkayShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub")!.Value ;
    }
}
//HttpContext → O an API’ye gelen isteği (request) temsil eder
//User → Bu isteği yapan kullanıcıyı temsil eder
//"sub" → Bu kullanıcının benzersiz ID’sidir