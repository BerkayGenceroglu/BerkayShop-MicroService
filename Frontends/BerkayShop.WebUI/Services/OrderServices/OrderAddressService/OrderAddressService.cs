using BerkayShop.DtoLayer.OrderDtos.OrderAddressDto;

namespace BerkayShop.WebUI.Services.OrderServices.OrderAddressService
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync("Addresses", createOrderAddressDto);
        }
    }
}
