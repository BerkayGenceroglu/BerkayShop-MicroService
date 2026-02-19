using BerkayShop.DtoLayer.CatalogDtos.BrandDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.BrandService
{
    public class BrandService:IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync("Brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync($"Brands/{id}");
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("Brands");
            return values!;
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdBrandDto>($"Brands/{id}");
            return value!;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync("Brands", updateBrandDto);
        }
    }
}
