using AutoMapper;
using BerkayShop.Catalog.Dtos.CategoryDtos;
using BerkayShop.Catalog.Entities;
using BerkayShop.Catalog.Settings;
using MongoDB.Driver;

namespace BerkayShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        //Category nesnelerini içeren MongoDB collection--Generic yapıda olduğu için ne yazarsak içinde o türde nesne tutan bir collection(tablo) verir.
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);/* MongoDB sunucusuna bağlantı kuruyor.*/
            var database = client.GetDatabase(_databaseSettings.DatabaseName); /*MongoDB sunucusundaki belirli bir veritabanını seçiyor.*/
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            //database içindeki adı _databaseSettings.ProductCollectionName olan MongoDB koleksiyonunu,
            //Product tipinde nesnelerle çalışacak şekilde al ve bunu _productCollection değişkenine ata.
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(y => y.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var value = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(value);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(y => y.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId,value);
        }
    }
}
