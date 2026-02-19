using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;

namespace BerkayShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("Products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"Products?id=" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("Products");
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetByIdProductDto>($"Products/{id}");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
           return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("Products/GetProductWithCategory");
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryID)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>($"Products/GetProductWithCategoryByCategoryId?categoryId=" + categoryID);
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            return _httpClient.PutAsJsonAsync("Products", updateProductDto);
        }
    }
}
