
namespace BerkayShop.WebUI.Services.StatisticServices.OrderStatisticService
{
    public class OrderStatisticService : IOrderStatisticService
    {
        private readonly HttpClient _httpClient;

        public OrderStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetOrderingTotalPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("Orderings/GetOrderingTotalPrice");
        }

        public async Task<DateTime> GetLastOrderDate()
        {
            return await _httpClient.GetFromJsonAsync<DateTime>("Orderings/GetLastOrderDate");
        }
    }
}
