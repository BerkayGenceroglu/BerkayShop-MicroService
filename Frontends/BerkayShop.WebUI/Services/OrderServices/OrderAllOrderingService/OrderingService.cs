using BerkayShop.DtoLayer.OrderDtos.OrderAllOrderDto;
using BerkayShop.DtoLayer.OrderDtos.OrderOrderingDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderAllOrderingService
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetAllOrderDto>> GetAllOrder()
        {
            return await _httpClient.GetFromJsonAsync<List<GetAllOrderDto>>($"Orderings");
        }
    }
}
