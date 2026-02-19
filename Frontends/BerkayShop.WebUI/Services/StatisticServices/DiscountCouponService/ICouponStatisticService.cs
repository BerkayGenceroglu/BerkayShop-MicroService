namespace BerkayShop.WebUI.Services.StatisticServices.DiscountCouponService
{
    public interface ICouponStatisticService
    {
        Task<int> GetDiscountCouponCountAsync();
    }
}
