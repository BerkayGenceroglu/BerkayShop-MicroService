using AutoMapper;
using BerkayShop.Catalog.Dtos.ProductImageDtos;
using BerkayShop.Catalog.Entities;
using BerkayShop.Catalog.Settings;
using MongoDB.Driver;

namespace BerkayShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;

        private readonly IMongoCollection<ProductImage> _productImageCollection;
        public ProductImageService(IMapper mapper,IDatabaseSettings _databasettings)
        {
            var client = new MongoClient(_databasettings.ConnectionString);
            var database = client.GetDatabase(_databasettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databasettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values =await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string productId)
        {
            var value = await _productImageCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, value);
        }
    }
}
