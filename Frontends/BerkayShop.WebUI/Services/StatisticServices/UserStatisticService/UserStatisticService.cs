
namespace BerkayShop.WebUI.Services.StatisticServices.UserStatisticService
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/Statistics/GetUserCount");
        }
    }
}
