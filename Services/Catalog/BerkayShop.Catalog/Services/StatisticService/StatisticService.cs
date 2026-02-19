using BerkayShop.Catalog.Entities;
using BerkayShop.Catalog.Settings;
using MongoDB.Driver;
using System.Diagnostics;

namespace BerkayShop.Catalog.Services.StatisticService
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
        }

        public long GetBrandCount()
        {
            return _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public long GetCategoryCount()
        {
            return _categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);

        }

        public async Task<string> GetMaxPriceProductName()
        {
            var values = await _productCollection.Find(FilterDefinition<Product>.Empty).ToListAsync();
            var MaxPriceProduct = values.OrderByDescending(x => x.ProductPrice).FirstOrDefault();
            return MaxPriceProduct!.ProductName;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var values = await _productCollection.Find(FilterDefinition<Product>.Empty).ToListAsync();
            var MinPriceProduct = values.OrderBy(x => x.ProductPrice).FirstOrDefault();
            return MinPriceProduct!.ProductName;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var values =await _productCollection.Find(FilterDefinition<Product>.Empty).ToListAsync();
            if (!values.Any())
                return 0;
            var avg = values.Select(x => x.ProductPrice).Where(x => x > 0).Average();
            return avg;
        }

        public long GetProductCount()
        {
            return _productCollection.CountDocuments(FilterDefinition<Product>.Empty);
        }

        public long GetTotalDiscountCount()
        {
            return _specialOfferCollection.CountDocuments(FilterDefinition<SpecialOffer>.Empty);
        }

    }
}
