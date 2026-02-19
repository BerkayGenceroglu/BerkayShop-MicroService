using BerkayShop.DtoLayer.IdentityDtos.UserDtos;
using BerkayShop.WebUI.Models;
using BerkayShop.WebUI.Services.Interfaces;

namespace BerkayShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAlluser()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultUserDto>>("api/users/GetAllUsers")!;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("api/users")!;
            //API’den kullanıcı bilgisini çek, JSON’u C# modeline çevir ve döndür.
        }
    }
}
