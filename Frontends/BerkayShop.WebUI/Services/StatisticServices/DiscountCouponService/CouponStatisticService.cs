
namespace BerkayShop.WebUI.Services.StatisticServices.DiscountCouponService
{
    public class CouponStatisticService : ICouponStatisticService
    {
        private readonly HttpClient _httpClient;

        public CouponStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Discount/GetDiscountCouponCount");
        }
    }
}
