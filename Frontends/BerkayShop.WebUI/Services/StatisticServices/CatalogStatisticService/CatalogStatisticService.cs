
using BerkayShop.DtoLayer.StatisticDtos.CatalogStatisticDto;

namespace BerkayShop.WebUI.Services.StatisticServices.CatalogStatisticService
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetBrandCount");
        }

        public async Task<long> GetCategoryCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetCategoryCount");
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await _httpClient.GetStringAsync("Statistics/GetMaxPriceProductName");
            return responseMessage;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await _httpClient.GetStringAsync("Statistics/GetMinPriceProductName");
            return responseMessage;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetProductAvgPrice")!;

        }

        public async Task<long> GetProductCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetProductCount");
        }

        public async Task<long> GetTotalDiscountCount()
        {
            return await _httpClient.GetFromJsonAsync<long>("Statistics/GetTotalDiscountCount");
        }
    }
}
//GetStringAsync(Üstteki): Gelen yanıtı olduğu gibi, "ham metin" (raw string) olarak okur. Yanıt ister düz yazı olsun ister JSON tırnakları içinde olsun, her şeyi olduğu gibi bir string değişkenine aktarır.

//GetFromJsonAsync<string> (Alttaki): Gelen yanıtın geçerli bir JSON formatı olmasını bekler. Eğer API sadece Laptop dönüyorsa, bu geçerli bir JSON string değildir (JSON olması için "Laptop" şeklinde çift tırnak içinde gelmelidir).

//GetStringAsync içeriği "yazı" olarak görür, GetFromJsonAsync ise içeriği "çözülmesi gereken bir şifre (format)" olarak görür.

//JSON formatında sayılar yalın halde yazılabilir. Yani API'den sadece 15 cevabı geldiğinde, bu geçerli bir JSON değeridir.
//JSON standartlarına göre bir metnin "JSON string" sayılabilmesi için mutlaka çift tırnak (" ") içinde olması gerekir.