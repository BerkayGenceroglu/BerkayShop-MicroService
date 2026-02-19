using BerkayShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.OfferDiscountService
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync("OfferDiscounts", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync($"OfferDiscounts/{id}");
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("OfferDiscounts");
            return values;
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdOfferDiscountDto>($"OfferDiscounts/{id}");
            return value!;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync("OfferDiscounts", updateOfferDiscountDto);
        }
    }
}
