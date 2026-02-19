using BerkayShop.DtoLayer.DiscountDtos;
using System.Net.Http.Json;

namespace BerkayShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            return _httpClient.GetFromJsonAsync<GetDiscountCodeDetailByCode>($"Discount/GetCodeDetailByCode/{code}")!;
        }
    }
}
