using BerkayShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace BerkayShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync("CargoCompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync($"CargoCompanies/{id}");
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDto>>("CargoCompanies");
            return values!;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdCargoCompanyDto>($"CargoCompanies/{id}");
            return value!;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync("CargoCompanies", updateCargoCompanyDto);
        }
    }
}
