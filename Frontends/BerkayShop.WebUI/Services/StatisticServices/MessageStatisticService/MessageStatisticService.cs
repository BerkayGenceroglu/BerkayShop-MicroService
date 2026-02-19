
namespace BerkayShop.WebUI.Services.StatisticServices.MessageStatisticService
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("Messages/GetTotalMessageCount")!;
        }

    }
}
