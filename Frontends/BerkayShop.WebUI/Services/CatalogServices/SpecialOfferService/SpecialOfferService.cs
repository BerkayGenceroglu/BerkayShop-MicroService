using BerkayShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.SpecialOfferService
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("SpecialOffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"SpecialOffers/{id}");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("SpecialOffers");
            return values;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdSpecialOfferDto>($"SpecialOffers/{id}");
            return value!;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("SpecialOffers", updateSpecialOfferDto);
        }
    }
}
