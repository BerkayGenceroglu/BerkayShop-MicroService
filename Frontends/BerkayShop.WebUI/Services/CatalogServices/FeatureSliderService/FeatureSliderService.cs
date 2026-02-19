using BerkayShop.DtoLayer.CatalogDtos.FeatureSlideDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.FeatureSliderService
{
    public class FeatureSliderService:IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync("FeatureSliders", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync($"FeatureSliders/{id}");
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            await _httpClient.PutAsync($"FeatureSliders/ChangeStatusToFalse/{id}",null);
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            await _httpClient.PutAsync($"FeatureSliders/ChangeStatusToTrue/{id}", null);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("FeatureSliders");
            return values;
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdFeatureSliderDto>($"FeatureSliders/{id}");
            return value!;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync("FeatureSliders", updateFeatureSliderDto);
        }
    }
}
