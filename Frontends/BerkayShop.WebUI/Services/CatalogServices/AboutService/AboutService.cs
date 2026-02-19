using BerkayShop.DtoLayer.CatalogDtos.AboutDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.AboutService
{
    public class AboutService:IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("Abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync($"Abouts/{id}");
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("Abouts");
            return values;
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdAboutDto>($"Abouts/{id}");
            return value!;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("Abouts", updateAboutDto);
        }
    }
}
