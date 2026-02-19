using AutoMapper;
using BerkayShop.Catalog.Dtos.FeatureSliderDtos;
using BerkayShop.Catalog.Entities;
using BerkayShop.Catalog.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BerkayShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(y => y.FeatureSliderId == id);
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            var value = await _featureSliderCollection.Find(y => y.FeatureSliderId == id).FirstOrDefaultAsync();
            value.Status = false;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == id, value);

        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            var value = await _featureSliderCollection.Find(y => y.FeatureSliderId == id).FirstOrDefaultAsync();
            value.Status = true;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == id, value);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);

        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find(y => y.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, value);
        }
    }
}
