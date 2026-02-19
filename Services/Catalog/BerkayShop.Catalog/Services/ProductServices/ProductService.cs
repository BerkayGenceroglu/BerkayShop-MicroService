using AutoMapper;
using BerkayShop.Catalog.Dtos.ProductDtos;
using BerkayShop.Catalog.Entities;
using BerkayShop.Catalog.Settings;
using MongoDB.Driver;

namespace BerkayShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper ,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
           await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value =await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            var newValues = _mapper.Map<List<ResultProductWithCategoryDto>>(values);

            foreach (var item in newValues)
            {
                var category = await _categoryCollection
                    .Find(x => x.CategoryId == item.CategoryId)
                    .FirstOrDefaultAsync();

                item.CategoryName = category?.CategoryName;
            }
            return newValues;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryID)
        {
            var values = await _productCollection.Find(x => x.CategoryId == categoryID).ToListAsync();
            var newValues = _mapper.Map<List<ResultProductWithCategoryDto>>(values);
            foreach (var item in newValues)
            {
                var category = await _categoryCollection
                    .Find(x => x.CategoryId == item.CategoryId)
                    .FirstOrDefaultAsync();

                item.CategoryName = category?.CategoryName;
            }
            return newValues;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
