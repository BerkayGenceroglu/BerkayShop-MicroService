using BerkayShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("ProductDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductDetails/{id}");
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("ProductDetails");
            return values;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdProductDetailDto>($"ProductDetails/{id}");
            return value!;
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string productId)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdProductDetailDto>($"ProductDetails/GetProductDetailByProductId/{productId}");
            return value!;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("ProductDetails", updateProductDetailDto);
        }
    }
}
