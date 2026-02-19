using BerkayShop.DtoLayer.OrderDtos.OrderOrderingDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderOrderingService
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetOrderingByUserIdDto>> GetOrderingByUserIdAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<List<GetOrderingByUserIdDto>>($"Orderings/GetOrderingByUserId/{userId}");
        }
    }
}
