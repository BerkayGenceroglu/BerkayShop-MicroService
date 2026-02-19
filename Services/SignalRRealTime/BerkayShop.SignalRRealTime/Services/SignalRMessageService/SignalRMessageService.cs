
namespace BerkayShop.SignalRRealTime.Services.SignalRMessageService
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetMessageCountByUserId(string receiverId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"http://localhost:7108/api/Messages/GetMessageCountByUserId/{receiverId}")!;
        }
    }
}
