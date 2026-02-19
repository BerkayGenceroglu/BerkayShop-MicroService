
namespace BerkayShop.SignalRRealTime.Services.SignalRCommentService
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("http://localhost:7107/api/CommentStatistics")!;
        }
    }
}
