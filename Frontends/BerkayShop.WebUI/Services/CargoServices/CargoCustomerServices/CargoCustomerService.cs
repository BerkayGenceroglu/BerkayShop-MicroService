using BerkayShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace BerkayShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByUserIdDto> GetCargoCustomerByUserIdAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoCustomerByUserIdDto>($"CargoCustomers/GetCargoCustomerByUserId/{userId}")!;
        }
    }
}
