
namespace BerkayShop.WebUI.Services.StatisticServices.CargoStatisticService
{
    public class CargoStatisticService : ICargoStatisticService
    {
        private readonly HttpClient _httpClient;

        public CargoStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCargoCompanyCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("CargoCompanies/GetTotalOrderCompanyCount");
        }
    }
}
