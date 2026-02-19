
namespace BerkayShop.WebUI.Services.StatisticServices.CommentStatisticService
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetActiveCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetActiveCommentCount")!;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetTotalCommentCount")!;
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetPassiveCommentCount")!;

        }

    }
}
