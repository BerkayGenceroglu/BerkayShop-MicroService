using BerkayShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.ProductImageService
{
    public class ProductImageService: IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("ProductImages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductImages/{id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("ProductImages");
            return values;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdProductImageDto>($"ProductImages/{id}");
            return value!;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string productId)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdProductImageDto>($"ProductImages/GetByProductIdProductImage/{productId}");
            return value!;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("ProductImages", updateProductImageDto);
        }
    }
}
